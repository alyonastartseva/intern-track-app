using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using Microsoft.OpenApi.Extensions;

namespace intern_track_back.ViewModels.Api.Vacancy.ResponseModels
{
    public class VacanciesResponseModel
    {
        public List<VacancyResponseModel> Vacancies { get; set; }

        public VacanciesResponseModel Init(UnitOfWork unitOfWork)
        {
            Vacancies = unitOfWork.VacancyRepository
                .Select(v => new VacancyResponseModel
                {
                    Description = v.Description,
                    Stack = v.Stack.GetDisplayName(),
                    TotalNumber = v.TotalNumber,
                    FreeNumber = v.TotalNumber - v.Students.Count,
                    Company = v.Company
                })
                .OrderBy(v => v.Company.Name)
                .ToList();

            return this;
        }
        
        /// <summary>
        /// Собрать список вакансия для определенной компании
        /// </summary>
        public VacanciesResponseModel InitForCompany(int companyId, UnitOfWork unitOfWork)
        {
            Vacancies = unitOfWork.VacancyRepository
                .Where(v => v.CompanyId == companyId)
                .Select(v => new VacancyResponseModel
                {
                    Description = v.Description,
                    Stack = v.Stack.GetDisplayName(),
                    TotalNumber = v.TotalNumber,
                    FreeNumber = v.TotalNumber - v.Students.Count,
                    Company = v.Company
                })
                .ToList();

            return this;
        }
    }
}