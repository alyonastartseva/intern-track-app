using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;

namespace intern_track_back.ViewModels.Api.StudentPlanForInterview.ResponseModels
{
    public class StudentPlanForInterviewListResponseModel
    {
        /// <summary>
        /// Список записей студентов в таблице пожеланий на интервью
        /// </summary>
        public ICollection<StudentPlanForInterviewResponseModel> InterviewPlansList { get; set; }

        public StudentPlanForInterviewListResponseModel Init(int companyId, UnitOfWork unitOfWork)
        {
            InterviewPlansList = unitOfWork.StudentPlanForInterviews
                .Where(p => p.CompanyId == companyId)
                .Select(p => new StudentPlanForInterviewResponseModel
                {
                    StudentName = p.Student.LastName + " " + p.Student.FirstName,
                    PreferableTime = p.PreferableTime,
                    Priority = p.Priority,
                    StackTypes = p.StackTypes.Aggregate("", (current, type) => current + (type + " "))
                })
                .ToList();

            return this;
        }
        
    }
}