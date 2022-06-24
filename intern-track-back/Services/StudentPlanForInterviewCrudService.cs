using System.Collections;
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

            foreach (var type in model.StackTypes)
            {
                CreateStackForInterviewPlan((StackType)type, studentPlanForInterview);
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

            List<StackType> stacksModel = new();
            foreach (var stackType in model.StackTypes)
            {
                stacksModel.Add((StackType)stackType);
            }

            studentPlanForInterview.PreferableTime = model.PreferableTime;
            studentPlanForInterview.Priority = model.Priority;

            // Удаляем стеки, удаленные пользователем
            var stackForInterviewPlanToRemove = _unitOfWork.StackForInterviewPlanRepository
                .Where(s => !stacksModel.Contains(s.StackType))
                .ToList();

            RemoveStackForInterviewPlan(stackForInterviewPlanToRemove);
            
            // Добавляем стеки, добавленные пользователем
            var stackTypes = _unitOfWork.StackForInterviewPlanRepository
                .Where(s => s.StudentPlanForInterviewId == studentPlanForInterview.Id)
                .Select(s => s.StackType)
                .ToList();

            foreach (var type in stacksModel)
            {
                if (!stackTypes.Contains(type))
                {
                    CreateStackForInterviewPlan(type, studentPlanForInterview);
                }
            }

            _unitOfWork.Save();
            return new ActionResult<int>(studentPlanForInterview.Id);
        }
        
        private void CreateStackForInterviewPlan(StackType type, StudentPlanForInterview studentPlanForInterview)
        {
            var stackForInterviewPlan = _unitOfWork.StackForInterviewPlanRepository.CreateNew();
            
            stackForInterviewPlan.StackType = type;
            stackForInterviewPlan.StudentPlanForInterviewId = studentPlanForInterview.Id;
            stackForInterviewPlan.StudentPlanForInterview = studentPlanForInterview;
        }
        
        private void RemoveStackForInterviewPlan(List<StackForInterviewPlan> stackForInterviewPlanList)
        {
            _unitOfWork.StackForInterviewPlanRepository.RemoveRange(stackForInterviewPlanList);
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
            var stacks = _unitOfWork.CompanyRepository
                .Where(c => c.Id == companyId)
                .SelectMany(c => c.Vacancies.Select(v => v.Stack))
                .Distinct()
                .ToList();

            List<Dictionary<string, string>> list = new ();
            foreach (var stack in stacks)
            {
                var keyAndValue = new Dictionary<string, string>();
                keyAndValue.Add("key", stack.GetHashCode().ToString());
                keyAndValue.Add("value", stack.GetDisplayName());
                list.Add(keyAndValue);
            }
			
            return JsonConvert.SerializeObject(list);
        }
    }
}