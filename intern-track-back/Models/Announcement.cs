using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Получатели уведомлений
        /// </summary>
        public ICollection<ApplicationUser> Receivers { get; set; }
    }
}