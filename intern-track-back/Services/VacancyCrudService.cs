using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using intern_track_back.ViewModels.Api.Vacancies.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Services
{
    public class VacancyCrudService
    {
        private readonly UnitOfWork _unitOfWork;

        public VacancyCrudService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult<int> CreateOrUpdate(VacancyRequestModel model, User current)
        {
            var result = model.Id > 0
                ? Update(model, current)
                : Create(model, current);

            return result;
        }

        private ActionResult<int> Create(VacancyRequestModel model, User current)
        {
            if (current.Role != RoleType.Company)
            {
                return new ActionResult<int>(new ForbidResult());
            }

            var vacancy = _unitOfWork.VacancyRepository.CreateNew();

            vacancy.Description = model.Description;
            vacancy.Stack = model.Stack;
            vacancy.TotalNumber = model.TotalNumber;
            vacancy.Company = _unitOfWork.CompanyRepository.First(c => c.Id == current.Id);
            
            _unitOfWork.Save();
            return new ActionResult<int>(vacancy.Id);
        }

        private ActionResult<int> Update(VacancyRequestModel model, User current)
        {
            var vacancy = _unitOfWork.VacancyRepository
                .FirstOrDefault(v => v.Id == model.Id);

            if (vacancy == null)
            {
                return new ActionResult<int>(new NotFoundResult());
            }

            if (current.Role != RoleType.Admin && 
                vacancy.CompanyId != current.Id)
            {
                return new ActionResult<int>(new ForbidResult());
            }
            
            vacancy.Description = model.Description;
            vacancy.Stack = model.Stack;
            vacancy.TotalNumber = model.TotalNumber;
            
            _unitOfWork.Save();
            return new ActionResult<int>(vacancy.Id);
        }

        public IActionResult Remove(int id, User current)
        {
            var vacancy = _unitOfWork.VacancyRepository
                .FirstOrDefault(v => v.Id == id);

            if (vacancy == null)
            {
                return new NotFoundResult();
            }

            if (current.Role != RoleType.Admin && 
                vacancy.CompanyId != current.Id)
            {
                return new ForbidResult();
            }
            
            _unitOfWork.VacancyRepository.Remove(vacancy);
            _unitOfWork.Save();
            
            return new OkResult();
        }
    }
}