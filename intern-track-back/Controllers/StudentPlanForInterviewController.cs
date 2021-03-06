using System;
using intern_track_back.Services;
using intern_track_back.ViewModels.Api.StudentPlanForInterviews.RequestModels;
using intern_track_back.ViewModels.Api.StudentPlanForInterviews.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentPlanForInterviewController : BaseController
    {
        public StudentPlanForInterviewController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        
        //todo сделать по ролям доступ: компания не может видеть столбец приоритета
        /// <summary>
        /// Получить таблицу желающих прособеседоваться по id компании
        /// </summary>
        /// <param name="companyId">Идентификатор компании</param>
        [HttpGet]
        [Route("StudentPlanForInterviewByCompanyId")]
        public StudentPlanForInterviewListResponseModel GetForCompany(int companyId, int currentUserId) 
            => new StudentPlanForInterviewListResponseModel().Init(companyId, UnitOfWork, currentUserId);

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
            
        [HttpGet]
        [Route("getstacksforcompany")]
        public string GetStacksForCompany(int companyId,
            [FromServices] StudentPlanForInterviewCrudService studentPlanForInterviewService)
        {
            return studentPlanForInterviewService.GetStacksForCompany(companyId, Current);
        }
    }
}