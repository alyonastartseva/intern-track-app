using intern_track_back.ViewModels.Api.Companies;
using intern_track_back.ViewModels.Api.Users.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        [HttpPost]
        [Route("getuserinfo")]
        public UserResponseModel GetUserInfo()
        {
            var currentUser = Current;

            var user = UnitOfWork.UserRepository.FirstOrDefault(x => x.Id == currentUser.Id);
            if (user == null)
            {
                return new UserResponseModel();
            }

            var model = new UserResponseModel
            {
                UserId = user.Id.ToString(),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                About = user.About,
                Role = user.Role
            };

            if (user.Role == Enumerations.RoleType.Student)
            {
                var student = UnitOfWork.StudentRepository.FirstOrDefault(x => x.Id == currentUser.Id);
                model.Course = student.Course;
            }
            else if (user.Role == Enumerations.RoleType.Company)
            {
                var company = UnitOfWork.CompanyRepository.FirstOrDefault(x => x.Id == currentUser.Id);
                model.CompanyAddress = company.Address;
                model.CompanyName = company.CompanyName;
            }
            else if (user.Role == Enumerations.RoleType.Deanery)
            {
                var deanery = UnitOfWork.DeaneryRepository.FirstOrDefault(x => x.Id == currentUser.Id);
                model.DeaneryAddress = deanery.Address;
            }

            return model;
        }

    }
}
