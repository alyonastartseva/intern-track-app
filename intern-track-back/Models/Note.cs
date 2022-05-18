using System;
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
        /// Это что??????????
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Идентификатор компании, которая создала заметку по студенту
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Компания, которая создала заметку по студенту
        /// </summary>
        public Company Company { get; set; }
        
        /// <summary>
        /// Идентификатор студента, относительно которого написана заметка
        /// </summary>
        public int StudentId { get; set; }
        
        /// <summary>
        /// Студент, относительно которого написана заметка
        /// </summary>
        public Student Student { get; set; }
    }
}