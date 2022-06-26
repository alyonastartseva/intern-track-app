using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using intern_track_back.ViewModels.Api.StudentPlanForInterviews.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;


namespace intern_track_back.Services
{
    public class StudentPlanForInterviewCrudService
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentPlanForInterviewCrudService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult<int> CreateOrUpdate(StudentPlanForInterviewRequestModel model, User current)
        {
            var result = model.Id > 0
                ? Update(model, current)
                : Create(model, current);

            return result;
        }

        private ActionResult<int> Create(StudentPlanForInterviewRequestModel model, User current)
        {
            /*if (current.Role != RoleType.Student)
            {
                return new ActionResult<int>(new ForbidResult());
            }*/
            
            var studentPlanForInterview = _unitOfWork.StudentPlanForInterviewRepository.CreateNew();
            
            studentPlanForInterview.PreferableTime = model.PreferableTime;
            studentPlanForInterview.Priority = model.Priority;
            studentPlanForInterview.CompanyId = model.CompanyId;
            studentPlanForInterview.StudentId = model.StudentId;

            foreach (var vacancyId in model.VacancyIds)
            {
                ConnectInterviewPlanWithVacancy(vacancyId, studentPlanForInterview);
            }
            
            _unitOfWork.Save();
            return new ActionResult<int>(studentPlanForInterview.Id);
        }

        private ActionResult<int> Update(StudentPlanForInterviewRequestModel model, User current)
        {
            var studentPlanForInterview = _unitOfWork.StudentPlanForInterviewRepository
                .FirstOrDefault(a => a.Id == model.Id);

            if (studentPlanForInterview == null)
            {
                return new ActionResult<int>(new NotFoundResult());
            }

            /*//Изменить запись может только тот же студент или админ
            if (current.Role != RoleType.Admin &&
                studentPlanForInterview.StudentId != current.Id)
            {
                return new ActionResult<int>(new ForbidResult());
            }*/

            studentPlanForInterview.PreferableTime = model.PreferableTime;
            studentPlanForInterview.Priority = model.Priority;

            // Удаляем стеки, удаленные пользователем
            var vacancyForInterviewPlanLinkToRemove = _unitOfWork.StudentPlanIntVacancyLinks
                .Where(l => l.StudentPlanForInterviewId == studentPlanForInterview.Id)
                .Where(l => !model.VacancyIds.Contains(l.VacancyId))
                .ToList();
            
            _unitOfWork.StudentPlanIntVacancyLinks.RemoveRange(vacancyForInterviewPlanLinkToRemove);

            // Добавляем стеки, добавленные пользователем
            var vacancyForInterviewPlanLinkToCreateIds = _unitOfWork.StudentPlanIntVacancyLinks
                .Where(l => l.StudentPlanForInterviewId == studentPlanForInterview.Id)
                .Select(s => s.VacancyId)
                .ToList();

            foreach (var vacancyId in model.VacancyIds)
            {
                if (!vacancyForInterviewPlanLinkToCreateIds.Contains(vacancyId))
                {
                    ConnectInterviewPlanWithVacancy(vacancyId, studentPlanForInterview);
                }
            }

            _unitOfWork.Save();
            return new ActionResult<int>(studentPlanForInterview.Id);
        }
        
        private void ConnectInterviewPlanWithVacancy(int vacancyId, StudentPlanForInterview studentPlanForInterview)
        {
            var interviewPlanVacancyLink = _unitOfWork.StudentPlanIntVacancyLinks.CreateNew();
            interviewPlanVacancyLink.VacancyId = vacancyId;
            interviewPlanVacancyLink.StudentPlanForInterviewId = studentPlanForInterview.Id;
            interviewPlanVacancyLink.StudentPlanForInterview = studentPlanForInterview;
        }

        public IActionResult Remove(int id, User current)
        {
            var studentPlanForInterview = _unitOfWork.StudentPlanForInterviewRepository
                .FirstOrDefault(a => a.Id == id);

            if (studentPlanForInterview == null)
            {
                return new NotFoundResult();
            }
            
            /*if (current.Role != RoleType.Admin &&
                studentPlanForInterview.StudentId != current.Id)
            {
                return new ForbidResult();
            }*/
            
            _unitOfWork.StudentPlanForInterviewRepository.Remove(studentPlanForInterview);
            _unitOfWork.Save();
            
            return new OkResult();
        }

        public string GetStacksForCompany(int companyId, User current)
        {
            var vacancies = _unitOfWork.VacancyRepository
                .Where(v => v.CompanyId == companyId)
                .ToList();

            List<Dictionary<string, string>> list = new ();
            foreach (var vacancy in vacancies)
            {
                var keyAndValue = new Dictionary<string, string>();
                keyAndValue.Add("key", vacancy.Id.ToString());
                keyAndValue.Add("value", vacancy.Stack);
                list.Add(keyAndValue);
            }
			
            return JsonConvert.SerializeObject(list);
        }
    }
}