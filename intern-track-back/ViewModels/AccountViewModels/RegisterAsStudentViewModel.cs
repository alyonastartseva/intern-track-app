using System.ComponentModel.DataAnnotations;

namespace intern_track_back.ViewModels.AccountViewModels
{
    public class RegisterAsStudentViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Курс")]
        public int Course { get; set; }
        
    }
}