namespace intern_track_back.Models
{
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Сам контакт
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание комментарий к контакту
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        public User? User { get; set; }
        public int? UserId { get; set; }
        
        /// <summary>
        /// Резюме
        /// </summary>
        public Resume? Resume { get; set; }
        public int? ResumeId { get; set; }
        
        /// <summary>
        /// Вакансия
        /// </summary>
        public Vacancy? Vacancy { get; set; }
        public int? VacancyId { get; set; }
    }
}