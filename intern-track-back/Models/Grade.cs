using System;

namespace intern_track_back.Models
{
    public class Grade
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Значение оуенки по предмету
        /// </summary>
        public int Value { get; set; }
    }
}