using System.Linq;
using intern_track_back.Data;
using intern_track_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace intern_track_back.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
 
        public CurrentUserService(UnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        /// <summary>
        /// Ключ, с которым в текущем экземпляре UnitOfWork хранится уже определенный CurrentUser. Если CurrentUser в текущем запросе еще не определяли, то по этому ключу ничего не будет найдено.
        /// </summary>
        private const string CurrentKey = "CurrentUser";

        public User GetCurrent()
        {
            User? current;

            if (_unitOfWork.Dictionary.ContainsKey(CurrentKey))
            {
                current = _unitOfWork.Dictionary[CurrentKey] as User;
                if (current != null)
                {
                    return current;
                }
            }
            
            var applicationUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext?.User);
            
            //var applicationUser = _userManager.FindByIdAsync(userId).Result; - получение пользователя по Id, пусть будет
            
            if (applicationUserId is null)
            {
                return new Guest();
            }

            var applicationUser = _unitOfWork.IdentityUsers
                .FirstOrDefault(a => a.Id == applicationUserId);
            
            if (applicationUser is null)
            {
                return new Guest();
            }

            current = _unitOfWork.UserRepository
                .FirstOrDefault(u => u.Id == applicationUser.UserId);
            
            if (current == null)
            {
                return new Guest();
            }
            
            _unitOfWork.Dictionary[CurrentKey] = current;
            _unitOfWork.GetContext().Attach(current);
            return current;
        }

        public User? GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository
                .FirstOrDefault(u => u.ApplicationUser.Email == email);
        }
    }
}