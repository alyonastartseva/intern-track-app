using System;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.ViewModels.Api.Interviews.RequestModels
{
    public class InterviewRequestModel
    {
        /// <summary>
        /// Идентификатор собеседования
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Дата и время, на которое назначено собеседование
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Формат собеседования
        /// </summary>
        public int Format { get; set; }

        // Id вакансии
        public int VacancyId { get; set; }
        
        /// <summary>
        /// Место для собеседования
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Студент, проходящий собеседование
        /// </summary>
        public int StudentId { get; set; }
        
        /// <summary>
        /// Компания, назначившая собеседование
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Статус интервью студента. Менять его может компания
        /// </summary>
        public int StudentInterviewStatusType { get; set; }

        public ActionResult<InterviewRequestModel> Init(int id, User current, UnitOfWork unitOfWork)
        {
            var interview = unitOfWork.InterviewRepository
                .FirstOrDefault(i => i.Id == id);

            if (interview == null)
            {
                return this;
            }
            
            if (current.Role != RoleType.Admin &&
                current.Id != interview.CompanyId)
            {
                return new ActionResult<InterviewRequestModel>(new ForbidResult());
            }

            Date = interview.Date;
            Format = interview.Format.GetHashCode();
            VacancyId = interview.VacancyId;
            Place = interview.Place;
            StudentId = interview.StudentId;
            StudentInterviewStatusType = interview.StudentInterviewStatusType.GetHashCode();

            return new ActionResult<InterviewRequestModel>(this);
        }
    }
}