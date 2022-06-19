using System;
using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Student : User
    {
        /// <summary>
        /// Номер курса обучения
        /// </summary>
        public int Course { get; set; }
        
        /// <summary>
        /// Статус активности студента в игре "попади на работу", что он уже сделал
        /// </summary>
        public StatusType Status { get; set; }
        
        /// <summary>
        /// Вакансия, на которую был принят студент
        /// </summary>
        public Vacancy? Vacancy { get; set; }
        public int?  VacancyId { get; set; }
        
        /// <summary>
        /// Список заметок от компаний относительно их желания принять студента
        /// </summary>
        public ICollection<Note> Notes { get; set; }
        
        /// <summary>
        /// Собеседование, назначенное студенту
        /// </summary>
        public ICollection<Interview> Interviews { get; set; }
        
        /// <summary>
        /// Резюме студентов
        /// </summary>
        public ICollection<Resume> Resumes { get; set; }
        
        /// <summary>
        /// Оценки студента по предметам
        /// </summary>
        public ICollection<Grade> Grades { get; set; }
        
        /// <summary>
        ///  Пожелания студента прособеседоваться в разных компаниях
        /// </summary>
        public ICollection<StudentPlanForInterview> StudentPlanForInterviews { get; set; }
    }
}