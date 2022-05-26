using System;
using intern_track_back.Services;
using intern_track_back.ViewModels.Api.StudentPlanForInterview.RequestModels;
using intern_track_back.ViewModels.Api.StudentPlanForInterview.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentPlanForInterviewApiController : BaseApiController
    {
        public StudentPlanForInterviewApiController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        
        //todo сделать по ролям доступ: компания не может видеть столбец приоритета
        /// <summary>
        /// Получить таблицу желающих прособеседоваться по id компании
        /// </summary>
        /// <param name="companyId">Идентификатор компании</param>
        [HttpGet]
        [Route("StudentPlanForInterviewByCompanyId")]
        public StudentPlanForInterviewListResponseModel GetForCompany(int companyId) 
            => new StudentPlanForInterviewListResponseModel().Init(companyId, UnitOfWork);
        
        //todo: только студенты могут добавлять данные в таблицу
        [HttpGet]
        [Route("create")]
        public StudentPlanForInterviewRequestModel Create()
            => new StudentPlanForInterviewRequestModel();
        
        //todo: изменять и удалять данные могут только тот, кто написал строку и суперадмин
        [HttpGet]
        [Route("update")]
        public ActionResult<StudentPlanForInterviewRequestModel> Update(int id)
            => new StudentPlanForInterviewRequestModel().Init(id, UnitOfWork);

        [HttpPost]
        [Route("createUpdate")]
        public ActionResult<int> CreateUpdate(
            [FromBody] StudentPlanForInterviewRequestModel model,
            [FromServices] StudentPlanForInterviewCrudService studentPlanForInterviewService)
        {
            return studentPlanForInterviewService.CreateOrUpdate(model, Current);
        }
        
        [HttpPost]
        [Route("remove")]
        public IActionResult Remove(int id,
            [FromServices] StudentPlanForInterviewCrudService studentPlanForInterviewService)
        {
            return studentPlanForInterviewService.Remove(id, Current);
        }
            
    }
}