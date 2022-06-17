using System;
using intern_track_back.Services;
using intern_track_back.ViewModels.Api.Vacancy.RequestModels;
using intern_track_back.ViewModels.Api.Vacancy.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyApiController : BaseApiController
    {
        public VacancyApiController(IServiceProvider serviceProvider) : base(serviceProvider)
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
        [Route("VacanciesByCompanyId")]
        public VacanciesResponseModel GetForCompany(int companyId)
            => new VacanciesResponseModel().InitForCompany(companyId, UnitOfWork);
        
        /// <summary>
        /// Получить модель для создания вакансии
        /// </summary>
        [HttpGet]
        [Route("create")]
        public VacancyRequestModel Create()
            => new VacancyRequestModel();
        
        /// <summary>
        /// Получить модель для редактирования вакансии
        /// </summary>
        [HttpGet]
        [Route("update")]
        public ActionResult<VacancyRequestModel> Update(int id)
            => new VacancyRequestModel().Init(id, UnitOfWork);
        
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