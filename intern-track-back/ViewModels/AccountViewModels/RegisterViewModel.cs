using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intern_track_back.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        /// <summary>
        /// На основании этого параметры мы будем выбирать, кого создать: студента/компанию/куратора/админа. Вставить проверку, что админа может создать только админ!
        /// </summary>
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Реальное имя")]
        public string? FirstName { get; set; }

        [Display(Name = "Реальная фамилия")]
        public string? LastName { get; set; }

        [Display(Name = "Наименование компании")]
        public string? CompanyName { get; set; }
        
        [Display(Name = "Информация, которую пользователь хочет предоставить о себе")]
        public string? About { get; set; }
        
        public int? UserId { get; set; }
    }
}
