using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.ViewModels.Api.Vacancies.RequestModels
{
    public class VacancyRequestModel
    {
        /// <summary>
        /// Идентификатор вакансии
        /// </summary>
        public int VacancyId { get; set; }
        
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Описание вакансии
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Стэк
        /// </summary>
        public string Stack { get; set; }
        
        /// <summary>
        /// Общее количество мест, которое выделила компания
        /// </summary>
        public int TotalNumber { get; set; }
        
        public ActionResult<VacancyRequestModel> Init(int id, UnitOfWork unitOfWork)
        {
            var vacancy = unitOfWork.VacancyRepository
                .FirstOrDefault(v => v.Id == id);
            
            if (vacancy == null)
            {
                return new ActionResult<VacancyRequestModel>(new NotFoundResult());
            }

            CompanyId = vacancy.CompanyId;
            Description = vacancy.Description;
            Stack = vacancy.Stack;
            TotalNumber = vacancy.TotalNumber;
            
            return new ActionResult<VacancyRequestModel>(this);
        }
    }
}