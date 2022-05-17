using System;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Note
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Это что?
        /// </summary>
        public string AdditionalInfo { get; set; }
        
        /// <summary>
        /// Решение компании относительно студента, желающего к ним попасть
        /// </summary>
        public RemarkType Remark { get; set; }
    }
}