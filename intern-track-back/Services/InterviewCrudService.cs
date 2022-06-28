using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using intern_track_back.ViewModels.Api.Interviews.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Services
{
    public class InterviewCrudService
    {
        private readonly UnitOfWork _unitOfWork;

        public InterviewCrudService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult<int> CreateOrUpdate(InterviewRequestModel model, User current)
        {
            var result = model.Id > 0
                ? Update(model, current)
                : Create(model, current);

            return result;
        }

        private ActionResult<int> Create(InterviewRequestModel model, User current)
        {
            /*if (current.Role != RoleType.Company)
            {
                return new ActionResult<int>(new ForbidResult());
            }*/

            var interview = _unitOfWork.InterviewRepository.CreateNew();

            var student = _unitOfWork.StudentRepository.FirstOrDefault(s => s.Id == model.StudentId);
            student.GeneralStudentStatus = (GeneralStudentStatusType)model.StudentInterviewStatusType;

            interview.Date = model.Date;
            interview.Format = (FormatType)model.Format; //todo добавить проверку! возможна ошибка
            interview.VacancyId = model.VacancyId;
            interview.Place = model.Place;
            interview.StudentId = model.StudentId;
            interview.CompanyId = model.CompanyId;
            interview.StudentInterviewStatusType = (StudentInterviewStatusType)model.StudentInterviewStatusType;
            
            if (interview.StudentInterviewStatusType == StudentInterviewStatusType.ConfirmOffer)
            {
                MakeStudentVacancyConnection(interview.StudentId, interview.VacancyId);
            }
            else
            {
                RemoveStudentVacancyConnection(interview.StudentId, interview.VacancyId);
            }
            
            _unitOfWork.Save();
            
            return new ActionResult<int>(interview.Id);
        }

        private ActionResult<int> Update(InterviewRequestModel model, User current)
        {
            var interview = _unitOfWork.InterviewRepository
                .FirstOrDefault(i => i.Id == model.Id);

            if (interview == null)
            {
                return new ActionResult<int>(new NotFoundResult());
            }

            var student = _unitOfWork.StudentRepository.FirstOrDefault(s => s.Id == model.StudentId);
            student.GeneralStudentStatus = (GeneralStudentStatusType)model.StudentInterviewStatusType;

            /*if (interview.CompanyId != current.Id &&
                current.Role != RoleType.Admin)
            {
                return new ActionResult<int>(new ForbidResult());
            }*/

            interview.Date = model.Date;
            interview.Format = (FormatType)model.Format;
            interview.VacancyId = model.VacancyId;
            interview.Place = model.Place;
            interview.StudentId = model.StudentId;
            interview.CompanyId = model.CompanyId;
            interview.StudentInterviewStatusType = (StudentInterviewStatusType)model.StudentInterviewStatusType;

            if (interview.StudentInterviewStatusType == StudentInterviewStatusType.ConfirmOffer)
            {
                MakeStudentVacancyConnection(interview.StudentId, interview.VacancyId);
            }
            else
            {
                RemoveStudentVacancyConnection(interview.StudentId, interview.VacancyId);
            }
            
            _unitOfWork.Save();
            
            return new ActionResult<int>(interview.Id);
        }

        public IActionResult Remove(int id, User current)
        {
            var interview = _unitOfWork.InterviewRepository
                .FirstOrDefault(i => i.Id == id);

            if (interview == null)
            {
                return new NotFoundResult();
            }

            /*if (interview.CompanyId != current.Id &&
                current.Role != RoleType.Admin)
            {
                return new ForbidResult();
            }*/
            
            _unitOfWork.InterviewRepository.Remove(interview);
            _unitOfWork.Save();
            
            return new OkResult();
        }

        private void MakeStudentVacancyConnection(int studentId, int vacancyId)
        {
            var student = _unitOfWork.StudentRepository
                .First(s => s.Id == studentId);

            student.VacancyId = vacancyId;
        }

        private void RemoveStudentVacancyConnection(int studentId, int vacancyId)
        {
            var student = _unitOfWork.StudentRepository
                .First(s => s.Id == studentId);

            student.VacancyId = null;
        }
    }
}