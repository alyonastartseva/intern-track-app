using System;
using System.Threading.Tasks;
using intern_track_back.Services;
using intern_track_back.ViewModels.Api.Announcements.RequestModels;
using intern_track_back.ViewModels.Api.Announcements.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementApiController : BaseApiController
    {
        
        public AnnouncementApiController(IServiceProvider serviceProvider, AnnouncementCrudService announcementCrudService) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Получить список объявлений, отсортированный по дате создания
        /// </summary>
        [HttpGet]
        [Route("index")]
        public AnnouncementListResponseModel Index() 
            => new AnnouncementListResponseModel().Init(UnitOfWork);
        
        /// <summary>
        /// Получить объявление по id
        /// </summary>
        [HttpGet]
        [Route("getById")]
        public AnnouncementResponseModel GetById(int id) 
            => new AnnouncementResponseModel().Init(id, UnitOfWork);

        /// <summary>
        /// Получить модель для создания объявления
        /// </summary>
        [HttpGet]
        [Route("create")]
        public AnnouncementRequestModel Create()
            => new AnnouncementRequestModel();

        /// <summary>
        /// Получить модель для редактирования объявления
        /// </summary>
        [HttpGet]
        [Route("edit")]
        public AnnouncementRequestModel Edit(int id)
            => new AnnouncementRequestModel().Init(id, UnitOfWork);

        /// <summary>
        /// Отредактировать существующее объявление или создать новое
        /// </summary>
        [HttpPost]
        [Route("edit")]
        public ActionResult<int> Edit([FromBody] AnnouncementRequestModel model, [FromServices] AnnouncementCrudService announcementService)
        {
            return announcementService.CreateOrUpdate(model);
        }
        
        /// <summary>
        /// Удалить объявление
        /// </summary>
        [HttpPost]
        [Route("remove")]
        public IActionResult Remove(int id, [FromServices] AnnouncementCrudService announcementService)
        {
            return announcementService.Remove(id);
        }
    }
}