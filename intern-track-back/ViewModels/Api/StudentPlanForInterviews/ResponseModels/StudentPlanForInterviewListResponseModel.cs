using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using Microsoft.OpenApi.Extensions;

namespace intern_track_back.ViewModels.Api.StudentPlanForInterviews.ResponseModels
{
    public class StudentPlanForInterviewListResponseModel
    {
        /// <summary>
        /// Список записей студентов в таблице пожеланий на интервью
        /// </summary>
        public ICollection<StudentPlanForInterviewResponseModel> InterviewPlansList { get; set; }

        public StudentPlanForInterviewListResponseModel Init(int companyId, UnitOfWork unitOfWork, User current)
        {
            InterviewPlansList = unitOfWork.StudentPlanForInterviewRepository
                .Where(p => p.CompanyId == companyId)
                .Select(p => new StudentPlanForInterviewResponseModel
                {
                    StudentName = p.Student.LastName + " " + p.Student.FirstName,
                    PreferableTime = p.PreferableTime,
                    Priority = p.Priority,
                    StackTypes = GetStackTypesString(p.StackTypes),
                    ResumeLink = p.ResumeLink,
                    CanBeModified = current.Role == RoleType.Admin || current.Id == p.StudentId
                })
                .ToList();

            return this;
        }

        private static string GetStackTypesString(ICollection<StackForInterviewPlan> stackTypes)
        {
             var result = stackTypes.Aggregate("", (current, type) => current + type.StackType.GetDisplayName() + " ");
             return result.Remove(result.Length - 1);
        }

    }
}