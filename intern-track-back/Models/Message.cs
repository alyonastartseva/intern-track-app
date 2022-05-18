namespace intern_track_back.Models
{
    public class Message : BaseEntity
    {
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Автор сообщения.
        /// </summary>
        public User User { get; set; }
        public int UserId { get; set; } 
        
        /// <summary>
        /// Чат, в котором отправлено сообщение
        /// </summary>
        public Chat Chat { get; set; } 
        
        /// <summary>
        /// Сообщение помечено как удаленное
        /// </summary>
        public bool IsDeleted { get; set; } 
    }
}