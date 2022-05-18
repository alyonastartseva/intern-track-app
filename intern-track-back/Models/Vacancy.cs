using System;
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
        public StackType Stack { get; set; }
        
        /// <summary>
        /// Названия проектов
        /// </summary>
        public ICollection<Project> Projects { get; set; }
        
        /// <summary>
        /// Контакты для связи
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }
        
        /// <summary>
        /// Компания, которой принадлежит данная вакансия
        /// </summary>
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}