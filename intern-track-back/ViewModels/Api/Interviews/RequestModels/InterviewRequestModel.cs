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
        public FormatType Format { get; set; }

        /// <summary>
        /// Стэк, на который студент будет собеседоваться
        /// </summary>
        public StackType Stack { get; set; }
        
        /// <summary>
        /// Место для собеседования
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Студент, проходящий собеседование
        /// </summary>
        public int StudentId { get; set; }

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
            Format = interview.Format;
            Stack = interview.Stack;
            Place = interview.Place;
            StudentId = interview.StudentId;

            return new ActionResult<InterviewRequestModel>(this);
        }
    }
}