namespace intern_track_back.Models
{
    public class StudentPlanIntVacancyLink : BaseEntity
    {
        public int StudentPlanForInterviewId { get; set; }
        public StudentPlanForInterview StudentPlanForInterview { get; set; }

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}