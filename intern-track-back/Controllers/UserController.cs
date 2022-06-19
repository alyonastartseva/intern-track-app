using intern_track_back.ViewModels.Api.Companies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Получить список всех компаний (отсортированы по названию компании)
        /// </summary>
        [HttpGet]
        [Route("getallcompanies")]
        public CompaniesResponseModel GetAllCompanies()
            => new CompaniesResponseModel().Init(UnitOfWork);
    }
}
