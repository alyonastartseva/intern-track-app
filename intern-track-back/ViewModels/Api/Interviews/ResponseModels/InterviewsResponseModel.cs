using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace intern_track_back.ViewModels.Api.Interviews.ResponseModels
{
    public class InterviewsResponseModel
    {
        public List<InterviewResponseModel> Interviews { get; set; }

        /// <summary>
        /// Список всех собеседований конкретной компании
        /// </summary>
        public ActionResult<InterviewsResponseModel> InitForCompany(int companyId, User current, UnitOfWork unitOfWork)
        {
            /*if (current.Role == RoleType.Student)
            {
                return new ActionResult<InterviewsResponseModel>(new ForbidResult());
            }*/
            
            Interviews = unitOfWork.InterviewRepository
                .Where(i => i.CompanyId == companyId)
                .Select(i => new InterviewResponseModel
                {
                    InterviewId = i.Id,
                    Date = i.Date,
                    Format = i.Format != 0 ? i.Format.GetDisplayName() : "",
                    VacancyId = i.VacancyId,
                    VacancyStack = i.Vacancy.Stack,
                    Place = i.Place,
                    CompanyId = i.CompanyId,
                    CompanyName = i.Company.CompanyName != null ? i.Company.CompanyName : "",
                    StudentId = i.StudentId,
                    StudentName = i.Student.LastName + " " + i.Student.FirstName,
                    StudentInterviewStatusType = i.StudentInterviewStatusType != 0 ? i.StudentInterviewStatusType.GetHashCode() : 0,
                    StudentInterviewStatusTypeName = i.StudentInterviewStatusType != 0 ? i.StudentInterviewStatusType.GetDisplayName() : "no status"
                })
                .ToList();
           

            return this;
        }

        /// <summary>
        /// Список всех собеседований конкретного студента
        /// </summary>
        public ActionResult<InterviewsResponseModel> InitForStudent(int studentId, User current, UnitOfWork unitOfWork)
        {
            /*if (current.Role == RoleType.Student &&
                current.Id != studentId)
            {
                return new ActionResult<InterviewsResponseModel>(new ForbidResult());
            }*/
            
            Interviews = unitOfWork.InterviewRepository
                .Where(i => i.StudentId == studentId)
                .Select(i => new InterviewResponseModel
                {
                    InterviewId = i.Id,
                    Date = i.Date,
                    Format = i.Format.GetDisplayName(),
                    VacancyStack = i.Vacancy.Stack,
                    Place = i.Place,
                    CompanyId = i.CompanyId,
                    CompanyName = i.Company.CompanyName,
                    StudentId = i.StudentId,
                    StudentName = i.Student.LastName + " " + i.Student.FirstName,
                    StudentInterviewStatusType = i.StudentInterviewStatusType != 0 ? i.StudentInterviewStatusType.GetHashCode() : 0,
                    StudentInterviewStatusTypeName = i.StudentInterviewStatusType != 0 ? i.StudentInterviewStatusType.GetDisplayName() : "no status"
                })
                .ToList();

            return this;
        }
    }
}