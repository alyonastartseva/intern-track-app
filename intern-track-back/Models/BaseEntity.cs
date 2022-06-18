using System;

namespace intern_track_back.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Автоматическое создание врменных отметок
        /// </summary>
        protected BaseEntity()
        {
            ModifyDateTime = CreateDateTime = DateTime.UtcNow;
        }
        
        /// <summary>
        /// Метод для обновления отметки последнего изменения
        /// </summary>
        public void UpdateModifiedTimestamp()
        {
            ModifyDateTime = DateTime.UtcNow;
        }
    }
}