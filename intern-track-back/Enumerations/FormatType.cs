using System.ComponentModel.DataAnnotations;

namespace intern_track_back.Enumerations
{
    /// <summary>
    /// Форматы собеседований
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Онлайн
        /// </summary>
        [Display(Name = "Online")]
        Online = 1,
        
        /// <summary>
        /// Оффлайн
        /// </summary>
        [Display(Name = "Offline")]
        Offline = 2
    }
}