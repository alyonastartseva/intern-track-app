using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Note : BaseEntity
    {
        // <summary>
        /// Решение компании относительно студента, желающего к ним попасть
        /// </summary>
        public RemarkType Remark { get; set; }
        
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string? AdditionalInfo { get; set; }

        /// <summary>
        /// Компания, которая создала заметку по студенту
        /// </summary>
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Студент, относительно которого написана заметка
        /// </summary>
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}