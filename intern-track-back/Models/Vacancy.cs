using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Vacancy : BaseEntity
    {
        /// <summary>
        /// Описание вакансии
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Стэк
        /// </summary>
        public string Stack { get; set; }
        
        /// <summary>
        /// Общее количество мест, которое выделила компания
        /// </summary>
        public int TotalNumber { get; set; }

        /// <summary>
        /// Компания, которой принадлежит данная вакансия
        /// </summary>
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Студенты, принятые в компанию на данную вакансию
        /// </summary>
        public ICollection<Student> Students { get; set; }
        
        /// <summary>
        /// Собеседования на данную вакансию
        /// </summary>
        public ICollection<Interview> Interviews { get; set; }
        
        /// <summary>
        /// Вакансии, на которые хочет прособеседоваться студент
        /// </summary>
        public ICollection<StudentPlanIntVacancyLink> StudentPlanIntVacancyLinks { get; set; }
    }
}