using System;
using System.Linq;
using intern_track_back.ViewModels.Api.Companies;
using intern_track_back.ViewModels.Api.Students;
using intern_track_back.ViewModels.Api.Users.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

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

        [HttpGet]
        [Route("getuserinfo")]
        public UserResponseModel GetUserInfo(int id)
        {
            var user = UnitOfWork.UserRepository.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new UserResponseModel();
            }

            var model = new UserResponseModel
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                About = user.About,
                Role = user.Role.GetDisplayName()
            };

            if (user.Role == Enumerations.RoleType.Student)
            {
                var student = UnitOfWork.StudentRepository.First(x => x.Id == id);
                model.Course = student.Course;
            }
            else if (user.Role == Enumerations.RoleType.Company)
            {
                var company = UnitOfWork.CompanyRepository.First(x => x.Id == id);
                model.CompanyAddress = company.Address;
                model.CompanyName = company.CompanyName;
            }
            else if (user.Role == Enumerations.RoleType.Deanery)
            {
                var deanery = UnitOfWork.DeaneryRepository.First(x => x.Id == id);
                model.DeaneryAddress = deanery.Address;
            }

            return model;
        }

        /// <summary>
        /// Получить список всех студентов (отсортированы по фамилии)
        /// </summary>
        [HttpGet]
        [Route("getallstudents")]
        public StudentsResponseModel GetAllStudents()
            => new StudentsResponseModel().Init(UnitOfWork);
    }
}
