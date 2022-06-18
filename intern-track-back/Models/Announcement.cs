namespace intern_track_back.Models
{
    public class Announcement : BaseEntity
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Text { get; set; }
    }
}