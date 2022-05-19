using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using intern_track_back.Models;
using intern_track_back.Models.AccountViewModels;
using Microsoft.Extensions.Logging;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            IServiceProvider serviceProvider, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory) : base(serviceProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return Ok();
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return StatusCode(423, new { message = "User account locked out" });
                }

                ModelState.AddModelError(String.Empty, "Invalid login attempt.");
                return BadRequest(new { message = "Login failed" });
            }

            return BadRequest(new { message = "Model is not valid" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                //Добавить сюда создание дубликата-пользователя (студента/компании/куратора - в зависимости от того, кто это будет)
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return StatusCode(201, new { message = "Account created" });
                }

                AddErrors(result);
            }

            return StatusCode(409, new { message = "Conflict" });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();
            this._logger.LogInformation(4, "User logged out.");
            return Ok();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(String returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.Redirect("/");
            }
        }

        #endregion
    }
}
