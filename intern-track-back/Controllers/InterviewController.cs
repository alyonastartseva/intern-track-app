using System;
using intern_track_back.Services;
using intern_track_back.ViewModels.Api.Interviews.RequestModels;
using intern_track_back.ViewModels.Api.Interviews.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewController : BaseController
    {
        public InterviewController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        
        /// <summary>
        /// Получить список вакансий для конкретной компании
        /// </summary>
        /// <param name="companyId">Идентификатор компании</param>
        [HttpGet]
        [Route("interviewsByCompanyId")]
        public ActionResult<InterviewsResponseModel> GetForCompany(int companyId)
            => new InterviewsResponseModel().InitForCompany(companyId, Current, UnitOfWork);
        
        /// <summary>
        /// Получить список всех вакансий (отсортированы по названию компании)
        /// </summary>
        /// <param name="studentId">Идентификатор студента</param>
        [HttpGet]
        [Route("interviewsByStudentId")]
        public ActionResult<InterviewsResponseModel> GetForStudent(int studentId)
            => new InterviewsResponseModel().InitForStudent(studentId, Current, UnitOfWork);
        
        /// <summary>
        /// Получить собеседование по id
        /// </summary>
        [HttpGet]
        [Route("interviewsByStudentId")]
        public ActionResult<InterviewResponseModel> GetById(int id)
            => new InterviewResponseModel().Init(id, Current, UnitOfWork);
        
        /// <summary>
        /// Получить модель для создания вакансии
        /// </summary>
        [HttpGet]
        [Route("create")]
        public InterviewRequestModel Create()
            => new InterviewRequestModel();
        
        /// <summary>
        /// Получить модель для редавтирования вакансии
        /// </summary>
        [HttpGet]
        [Route("update")]
        public ActionResult<InterviewRequestModel> Update(int id)
            => new InterviewRequestModel().Init(id, Current, UnitOfWork);
        
        [HttpPost]
        [Route("createUpdate")]
        public ActionResult<int> CreateUpdate(
            [FromBody] InterviewRequestModel model,
            [FromServices] InterviewCrudService interviewCrudService)
        {
            return interviewCrudService.CreateOrUpdate(model, Current);
        }
        
        [HttpPost]
        [Route("remove")]
        public IActionResult Remove(int id,
            [FromServices] InterviewCrudService interviewCrudService)
        {
            return interviewCrudService.Remove(id, Current);
        }
    }
}