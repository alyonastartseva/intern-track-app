using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Deanery : User
    {
        /// <summary>
        /// Адрес компании (реальный? имейл? что имелось ввиду)
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Оценки, выставленные деканатом студентам
        /// </summary>
        public ICollection<Grade> Grades { get; set; }
    }
}