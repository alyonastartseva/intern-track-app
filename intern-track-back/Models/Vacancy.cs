using System;
using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Описание вакансии
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Стэк
        /// </summary>
        public StackType Stack { get; set; }
        
        /// <summary>
        /// Названия проектов
        /// </summary>
        public ICollection<string> Projects { get; set; }
        
        /// <summary>
        /// Контакты для связи
        /// </summary>
        public ICollection<string> Contacts { get; set; }
    }
}