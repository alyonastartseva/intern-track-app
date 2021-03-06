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
        /// Вакансия, на которую студент будет собеседоваться
        /// </summary>
        public Vacancy Vacancy { get; set; }
        public int  VacancyId { get; set; }

        /// <summary>
        /// Место для собеседования
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Статус интервью студента. Менять его может компания
        /// </summary>
        public StudentInterviewStatusType StudentInterviewStatusType { get; set; } = StudentInterviewStatusType.Waiting;

        /// <summary>
        /// Компания, проводящая собеседование
        /// </summary>
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Студент, проходящий собеседование
        /// </summary>
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}