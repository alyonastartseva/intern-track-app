using System;
using intern_track_back.Services;
using intern_track_back.ViewModels.Api.Vacancies.RequestModels;
using intern_track_back.ViewModels.Api.Vacancies.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyController : BaseController
    {
        public VacancyController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Получить список всех вакансий (отсортированы по названию компании)
        /// </summary>
        [HttpGet]
        [Route("index")]
        public VacanciesResponseModel Index()
            => new VacanciesResponseModel().Init(UnitOfWork);
        
        /// <summary>
        /// Получить список вакансий для конкретной компании
        /// </summary>
        /// <param name="companyId"></param>
        [HttpGet]
        [Route("vacanciesByCompanyId")]
        public VacanciesResponseModel GetForCompany(int companyId)
            => new VacanciesResponseModel().InitForCompany(companyId, UnitOfWork);

        [HttpPost]
        [Route("createUpdate")]
        public ActionResult<int> CreateUpdate(
            [FromBody] VacancyRequestModel model,
            [FromServices] VacancyCrudService vacancyService)
        {
            return vacancyService.CreateOrUpdate(model, Current);
        }
        
        [HttpPost]
        [Route("remove")]
        public IActionResult Remove(int id,
            [FromServices] VacancyCrudService vacancyService)
        {
            return vacancyService.Remove(id, Current);
        }
    }
}