namespace intern_track_back.Models
{
    public class Contact
    {
        /// <summary>
        /// Сам контакт
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание комментарий к контакту
        /// </summary>
        public string? Description { get; set; }
    }
}