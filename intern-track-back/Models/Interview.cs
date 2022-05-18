using System;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Interview : BaseEntity
    {
        /// <summary>
        /// Дата и время, на которое назначено собеседование
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Формат собеседования
        /// </summary>
        public FormatType Format { get; set; }

        /// <summary>
        /// Стэк, на который студент будет собеседоваться
        /// </summary>
        public StackType Stack { get; set; }
        
        /// <summary>
        /// Место для собеседования
        /// </summary>
        public string Place { get; set; }
        
        /// <summary>
        /// Идентификатор компании, проводящей собеседование
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Компания, проводящая собеседование
        /// </summary>
        public Company Company { get; set; }
        
        /// <summary>
        /// Идентификатор студента, проходящего собеседование
        /// </summary>
        public int StudentId { get; set; }
        
        /// <summary>
        /// Студент, проходящий собеседование
        /// </summary>
        public Student Student { get; set; }
    }
}