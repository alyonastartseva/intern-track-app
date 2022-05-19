using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class Resume : BaseEntity
    {
        /// <summary>
        /// О студенте
        /// </summary>
        public string About { get; set; }
        
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
        /// Студент, которой принадлежит данное резюме
        /// </summary>
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}