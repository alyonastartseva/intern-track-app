namespace intern_track_back.Models
{
    public class Project : BaseEntity
    {
        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание проекта
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Резюме
        /// </summary>
        public Resume? Resume { get; set; }
        public int? ResumeId { get; set; }
    }
}