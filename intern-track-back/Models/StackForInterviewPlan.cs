using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    /// <summary>
    /// Связь между стеком и желаниеями студентов прособеседоваться
    /// </summary>
    public class StackForInterviewPlan : BaseEntity
    {
        /// <summary>
        /// Позиции, на которые хочет прособеседоваться студент
        /// </summary>
        public StackType StackType { get; set; }
        
        /// <summary>
        /// Таблица пожеланий студентов прособеседоваться
        /// </summary>
        public StudentPlanForInterview StudentPlanForInterview { get; set; }
        public int StudentPlanForInterviewId { get; set; }
    }
}