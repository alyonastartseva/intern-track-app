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
        /// <summary>
        /// Дата и время, на которое назначено собеседование
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Формат собеседования
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Стэк, на который студент будет собеседоваться
        /// </summary>
        public string Stack { get; set; }
        
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

        public ActionResult<InterviewResponseModel> Init(int id, User current, UnitOfWork unitOfWork)
        {
            var interview = unitOfWork.InterviewRepository
                .Include(i => i.Company)
                .Include(i => i.Student)
                .FirstOrDefault(i => i.Id == id);

            if (interview == null)
            {
                return this;
            }
            
            if (current.Role == RoleType.Student &&
                current.Id != interview.StudentId)
            {
                return new ActionResult<InterviewResponseModel>(new ForbidResult());
            }

            Date = interview.Date;
            Format = interview.Format.GetDisplayName();
            Stack = interview.Stack;
            Place = interview.Place;
            CompanyId = interview.CompanyId;
            CompanyName = interview.Company.CompanyName;
            StudentId = interview.StudentId;
            StudentName = interview.Student.LastName + " " + interview.Student.FirstName;

            return new ActionResult<InterviewResponseModel>(this);
        }
    }
}