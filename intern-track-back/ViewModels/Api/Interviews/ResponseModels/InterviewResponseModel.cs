using System;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace intern_track_back.ViewModels.Api.Interviews.ResponseModels
{
    public class InterviewResponseModel
    {
        public int InterviewId { get; set; }

        /// <summary>
        /// Дата и время, на которое назначено собеседование
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Формат собеседования
        /// </summary>
        public string Format { get; set; }
        
        /// <summary>
        /// Идентификатор вакансии
        /// </summary>
        public int VacancyId { get; set; }

        /// <summary>
        /// Стэк, на который студент будет собеседоваться
        /// </summary>
        public string VacancyStack { get; set; }

        /// <summary>
        /// Место для собеседования
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Компания, проводящая собеседование
        /// </summary>
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        
        /// <summary>
        /// Студент, проходящий собеседование
        /// </summary>
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        
        /// <summary>
        /// Статус интервью студента. Менять его может компания
        /// </summary>
        public int StudentInterviewStatusType { get; set; }

        public string StudentInterviewStatusTypeName { get; set; }

        public ActionResult<InterviewResponseModel> Init(int id, User current, UnitOfWork unitOfWork)
        {
            var interview = unitOfWork.InterviewRepository
                .Include(i => i.Company)
                .Include(i => i.Student)
                .Include(i => i.Vacancy)
                .FirstOrDefault(i => i.Id == id);

            if (interview == null)
            {
                return this;
            }
            
            /*if (current.Role == RoleType.Student &&
                current.Id != interview.StudentId)
            {
                return new ActionResult<InterviewResponseModel>(new ForbidResult());
            }*/

            Date = interview.Date;
            Format = interview.Format.GetDisplayName();
            VacancyStack = interview.Vacancy.Stack;
            Place = interview.Place;
            CompanyId = interview.CompanyId;
            CompanyName = interview.Company.CompanyName;
            StudentId = interview.StudentId;
            StudentName = interview.Student.LastName + " " + interview.Student.FirstName;
            StudentInterviewStatusType = interview.StudentInterviewStatusType.GetHashCode();
            StudentInterviewStatusTypeName = GetStudentStatusName(interview.StudentInterviewStatusType);

            return new ActionResult<InterviewResponseModel>(this);
        }
        
        private static string GetStudentStatusName(StudentInterviewStatusType statusType)
        {
            switch (statusType)
            {
                case Enumerations.StudentInterviewStatusType.Waiting:
                    return "Собеседование ожидается";
                case Enumerations.StudentInterviewStatusType.Happened:
                    return "Собеседование пройдено";
                case Enumerations.StudentInterviewStatusType.Denied:
                    return "Отказано";
                case Enumerations.StudentInterviewStatusType.SendOffer:
                    return "Предложение оффера";
                case Enumerations.StudentInterviewStatusType.ConfirmOffer:
                    return "Оффер подтвержден";
            }

            return "";
        }
    }
}