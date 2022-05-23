using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace intern_track_back.ViewModels.Api.StudentPlanForInterview.RequestModels
{
    public class StudentPlanForInterviewRequestModel
    {
        /// <summary>
        /// Компанию, в которую студент хочет попробовать пройти
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Предпочтительное время для собеседования
        /// </summary>
        public string PreferableTime { get; set; }

        /// <summary>
        /// Позиции, на которые хочет прособеседоваться студент
        /// </summary>
        public ICollection<StackType> StackTypes { get; set; }
        
        /// <summary>
        /// Приоритет этой компании в глазах студента
        /// </summary>
        public int? Priority { get; set; }

        public ActionResult<StudentPlanForInterviewRequestModel> Init(int id, UnitOfWork unitOfWork)
        {
            var studentPlanForInterview = unitOfWork.StudentPlanForInterviews
                .Where(p => p.Id == id)
                .Include(p => p.StackTypes)
                .FirstOrDefault();

            if (studentPlanForInterview == null)
            {
                return new ActionResult<StudentPlanForInterviewRequestModel>(new NotFoundResult());
            }

            CompanyId = studentPlanForInterview.CompanyId;
            PreferableTime = studentPlanForInterview.PreferableTime;
            Priority = studentPlanForInterview.Priority;
            StackTypes = studentPlanForInterview.StackTypes
                .Select(t => t.StackType)
                .ToList();

            return new ActionResult<StudentPlanForInterviewRequestModel>(this);
        }
    }
}