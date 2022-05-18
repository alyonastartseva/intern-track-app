using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Deanery : User
    {
        /// <summary>
        /// Географический адрес деканата
        /// </summary>
        public string? Address { get; set; }
        
        /// <summary>
        /// Оценки, выставленные деканатом студентам
        /// </summary>
        public ICollection<Grade> Grades { get; set; }
    }
}