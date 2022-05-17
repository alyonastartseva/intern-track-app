using System.ComponentModel.DataAnnotations;

namespace intern_track_back.Enumerations
{
    /// <summary>
    /// Варианты стека
    /// </summary>
    public enum StackType
    {
        /// <summary>
        /// Frontend
        /// </summary>
        [Display(Name = "Frontend")]
        Frontend = 1,
        
        /// <summary>
        /// Backend
        /// </summary>
        [Display(Name = "Backend")]
        Backend = 2,
        
        /// <summary>
        /// Machine Learning
        /// </summary>
        [Display(Name = "Machine Learning")]
        ML = 3,
        
        /// <summary>
        /// Analytic
        /// </summary>
        [Display(Name = "Analytic")]
        Analytic = 4
    }
}