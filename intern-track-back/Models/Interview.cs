using System;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Interview
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
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
    }
}