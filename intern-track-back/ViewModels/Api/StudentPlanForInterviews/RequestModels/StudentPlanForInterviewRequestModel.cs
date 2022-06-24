using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace intern_track_back.ViewModels.Api.StudentPlanForInterviews.RequestModels
{
    public class StudentPlanForInterviewRequestModel
    {
        /// <summary>
        /// Идентификатор сущности записи
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Компанию, в которую студент хочет попробовать пройти
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Студент, для которого создана запись
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Предпочтительное время для собеседования
        /// </summary>
        public string PreferableTime { get; set; }

        /// <summary>
        /// Позиции, на которые хочет прособеседоваться студент
        /// </summary>
        public ICollection<int> StackTypes { get; set; }
        
        /// <summary>
        /// Приоритет этой компании в глазах студента
        /// </summary>
        public int? Priority { get; set; }
        
        
        
        /// <summary>
        /// Может быть изменен текущим пользователем
        /// </summary>
        public bool CanBeModified { get; set; }

        public ActionResult<StudentPlanForInterviewRequestModel> Init(int id, UnitOfWork unitOfWork, User current)
        {
            var studentPlanForInterview = unitOfWork.StudentPlanForInterviewRepository
                .Where(p => p.Id == id)
                .Include(p => p.StackTypes)
                .FirstOrDefault();

            if (studentPlanForInterview == null)
            {
                return new ActionResult<StudentPlanForInterviewRequestModel>(new NotFoundResult());
            }

            Id = studentPlanForInterview.Id;
            StudentId = studentPlanForInterview.StudentId;
            CompanyId = studentPlanForInterview.CompanyId;
            PreferableTime = studentPlanForInterview.PreferableTime;
            Priority = studentPlanForInterview.Priority;
            StackTypes = studentPlanForInterview.StackTypes
                .Select(t => t.StackType.GetHashCode())
                .ToList();
            CanBeModified = current.Role == RoleType.Admin || current.Id == studentPlanForInterview.StudentId;

            return new ActionResult<StudentPlanForInterviewRequestModel>(this);
        }
    }
}