namespace intern_track_back.Models
{
    public class UserChat : BaseEntity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
        public int UserId { get; set; }
        
        /// <summary>
        /// Чат
        /// </summary>
        public Chat Chat { get; set; }
        public int ChatId { get; set; }
    }
}