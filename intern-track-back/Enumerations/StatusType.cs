using System.ComponentModel.DataAnnotations;

namespace intern_track_back.Enumerations
{
    public enum StatusType
    {
        /// <summary>
        /// Студент ничего не делал
        /// </summary>
        [Display(Name = "Студент ничего не делал")]
        DidNothing = 1,
        
        /// <summary>
        /// Студент сходил на собеседование
        /// </summary>
        [Display(Name = "Студент сходил на собеседование")]
        VisitedInterview = 2,
        
        /// <summary>
        /// Студент получил тестовое
        /// </summary>
        [Display(Name = "Студент получил тестовое")]
        ReceivedTestTask = 3,
        
        /// <summary>
        /// Студент выполнил тестовое
        /// </summary>
        [Display(Name = "Студент выполнил тестовое")]
        PassedTestTask = 4,
        
        /// <summary>
        /// Студент получил оффер
        /// </summary>
        [Display(Name = "Студент получил оффер")]
        ReceivedOffer = 5
    }
}