using System.Collections.Generic;

namespace intern_track_back.Models
{
    /// <summary>
    /// Строка таблицы пожеланий студентов прособеседоваться
    /// </summary>
    public class StudentPlanForInterview : BaseEntity
    {
        /// <summary>
        /// Компанию, в которую студент хочет попробовать пройти
        /// </summary>
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Студент, желающий попасть в компанию
        /// </summary>
        public Student Student { get; set; }
        public int StudentId { get; set; }
        
        /// <summary>
        /// Предпочтительное время для собеседования
        /// </summary>
        public string PreferableTime { get; set; }

        /// <summary>
        /// Позиции, на которые хочет прособеседоваться студент
        /// </summary>
        public ICollection<StackForInterviewPlan> StackTypes { get; set; }
        
        /// <summary>
        /// Внешняя ссылка на резюме
        /// </summary>
        public string? ResumeLink { get; set; }
        
        /// <summary>
        /// Приоритет этой компании в глазах студента
        /// </summary>
        public int? Priority { get; set; }
    }
    
}