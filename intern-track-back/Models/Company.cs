using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Company : User
    {
        /// <summary>
        /// Адрес компании (реальный? имейл? что имелось ввиду)
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Список вакансий
        /// </summary>
        public ICollection<Vacancy> Vacancies { get; set; }
        
        /// <summary>
        /// Заметки по студентам (желание компании принять студента)
        /// </summary>
        public ICollection<Note> Notes { get; set; }
        
        /// <summary>
        /// Собеседования, назначенные компанией
        /// </summary>
        public ICollection<Interview> Interviews { get; set; }
    }
}