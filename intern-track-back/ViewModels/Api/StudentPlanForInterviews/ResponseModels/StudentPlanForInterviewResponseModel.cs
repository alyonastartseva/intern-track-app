namespace intern_track_back.ViewModels.Api.StudentPlanForInterviews.ResponseModels
{
    public class StudentPlanForInterviewResponseModel
    {
        /// <summary>
        /// Имя студента, желающий попасть в компанию
        /// </summary>
        public string StudentName { get; set; }
        
        /// <summary>
        /// Предпочтительное время для собеседования
        /// </summary>
        public string PreferableTime { get; set; }

        /// <summary>
        /// Позиции, на которые хочет прособеседоваться студент
        /// </summary>
        public string StackTypes { get; set; }
        
        /// <summary>
        /// Приоритет этой компании в глазах студента
        /// </summary>
        public int? Priority { get; set; }
    }
}