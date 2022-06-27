using System.ComponentModel.DataAnnotations;

namespace intern_track_back.Enumerations
{
    public enum GeneralStudentStatusType
    {
        /*[Display(Name = "Студент ничего не делал")]
        DidNothing = 1,
        
        [Display(Name = "Студенту назначали собеседования")]
        VisitedInterview = 2,
        
        [Display(Name = "Студент получил оффер")]
        ReceivedOffer = 3,

        [Display(Name = "Студент принял оффер")]
        ConfirmedOffer = 4*/
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