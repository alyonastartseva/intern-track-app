using System.ComponentModel.DataAnnotations;

namespace intern_track_back.ViewModels.AccountViewModels
{
    public class RegisterAsStudentViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Реальное имя")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Реальная фамилия")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Курс")]
        public int Course { get; set; }
        
    }
}