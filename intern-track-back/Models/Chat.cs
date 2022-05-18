using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Chat : BaseEntity
    {
        /// <summary>
        /// Пользователи, состоящие в чате
        /// </summary>
        public ICollection<User> Contingent { get; set; }
        
        /// <summary>
        /// Чат отправлен в архив
        /// </summary>
        public bool IsArchived { get; set; }
        
        /// <summary>
        /// Все сообщения в чате
        /// </summary>
        public ICollection<Message> Messages { get; set; }
        
        /// <summary>
        /// Пользователи, состоящие в чате
        /// </summary>
        public ICollection<UserChat> Users { get; set; }
    }
}