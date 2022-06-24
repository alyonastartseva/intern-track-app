using System.ComponentModel.DataAnnotations;

namespace intern_track_back.Enumerations
{
    public enum StudentInterviewStatusType
    {
        [Display(Name = "Собеседование ожидается")]
        Waiting = 1,
        
        [Display(Name = "Собеседование пройдено")]
        Happened = 2,
        
        [Display(Name = "Отказано")]
        Denied = 3,
        
        [Display(Name = "Предложение оффера")]
        SendOffer = 4,
        
        [Display(Name = "Оффер подтвержден")]
        ConfirmOffer = 5
    }
}