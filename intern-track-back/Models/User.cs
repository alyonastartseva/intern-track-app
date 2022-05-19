using System.Collections.Generic;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    public class User : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Текстовая информация о пользователе, которую он предоставил
        /// </summary>
        public string? About { get; set; }
        
        /// <summary>
        /// Роль
        /// </summary>
        public RoleType Role { get; set; }
        
        /// <summary>
        /// Контакты, способы связи с пользователем
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// Чаты, в которых состоит пользователь
        /// </summary>
        public ICollection<UserChat> Chats { get; set; }
    }
}