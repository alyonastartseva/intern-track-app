using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Company : User
    {
        /// <summary>
        /// Географический адрес компании
        /// </summary>
        public string? Address { get; set; }
        
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
        
        /// <summary>
        /// Таблица пожеланий студентов прособеседоваться
        /// </summary>
        public ICollection<StudentPlanForInterview> StudentPlanForInterviews { get; set; }
    }
}