using System;
using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class User : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Текстовая информация о пользователе, которую он предоставил
        /// </summary>
        public string About { get; set; }
        
        /// <summary>
        /// Роль
        /// </summary>
        public RoleType Role { get; set; }
        
        /// <summary>
        /// Контакты, способы связи с пользователем
        /// </summary>
        public ICollection<string> Contacts { get; set; }

        /// <summary>
        /// Объявления, отправленные пользователю
        /// </summary>
        public ICollection<Announcement> Announcements { get; set; }
        
        /// <summary>
        /// Список полученных сообщений
        /// </summary>
        public ICollection<Message> ReceivedMessages { get; set; }
        
        /// <summary>
        /// Список отправленных сообщений
        /// </summary>
        public ICollection<Message> SentMessages { get; set; }
    }
}