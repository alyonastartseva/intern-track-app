using System;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Номер курса обучения
        /// </summary>
        public int Course { get; set; }
        
        /// <summary>
        /// Статус активности студента в игре "попади на работу", что он уже сделал
        /// </summary>
        public StatusType Status { get; set; }
    }
}