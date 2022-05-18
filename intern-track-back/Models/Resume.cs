using System;
using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Resume : BaseEntity
    {
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
        
        /// <summary>
        /// Идентификатор студента, которой принадлежит данное резюме
        /// </summary>
        public int StudentId { get; set; }
        
        /// <summary>
        /// Студент, которой принадлежит данное резюме
        /// </summary>
        public Student Student { get; set; }
    }
}