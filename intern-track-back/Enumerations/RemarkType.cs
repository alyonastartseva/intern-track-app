using System.ComponentModel.DataAnnotations;

namespace intern_track_back.Enumerations
{
    /// <summary>
    /// Вердикт компании относительно студента
    /// </summary>
    public enum RemarkType
    {
        /// <summary>
        /// Компания решила взять студента на стажировку
        /// </summary>
        [Display(Name = "Компания решила взять студента на стажировку")]
        Accept = 1,
        
        /// <summary>
        /// Компания решила не брать студента на стажировку
        /// </summary>
        [Display(Name = "Компания решила не брать студента на стажировку")]
        NotAccept = 2,
        
        /// <summary>
        /// Компания возможно возьмёт студента на стажировку
        /// </summary>
        [Display(Name = "Компания возможно возьмёт студента на стажировку")]
        MayBeAccept = 3,
        
        /// <summary>
        /// Человек рассматривает нашу компанию, как запас
        /// </summary>
        [Display(Name = "Человек рассматривает нашу компанию, как запас")]
        WeAreFallbackForStudent = 4
    }
}