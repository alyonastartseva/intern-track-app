using intern_track_back.Data;
using intern_track_back.Enumerations;
using intern_track_back.Models;
using intern_track_back.ViewModels.AccountViewModels;

namespace intern_track_back.Services
{
    public class AccountService
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RegisterAsStudent(RegisterAsStudentViewModel model, ApplicationUser applicationUser)
        {
            var user = _unitOfWork.StudentRepository.CreateNew();

            user.ApplicationUserId = applicationUser.Id;
            user.ApplicationUser = applicationUser;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Course = model.Course;
            user.About = model.About;
            user.Role = RoleType.Student;
            user.GeneralStudentStatus = GeneralStudentStatusType.DidNothing;

            _unitOfWork.Save();
        }

        public void Register(RegisterViewModel model, ApplicationUser applicationUser)
        {
            User user;
            switch (model.Role.ToLower())
            {
                case "company":
                    var company = _unitOfWork.CompanyRepository.CreateNew();
                    company.Role = RoleType.Company;
                    company.ApplicationUserId = applicationUser.Id;
                    company.ApplicationUser = applicationUser;
                    company.Email = model.Email;
                    company.About = model.About;
                    company.CompanyName = model.CompanyName;
                    company.FirstName = model.FirstName;
                    company.LastName = model.LastName;
                    break;
                case "curator":
                    user = _unitOfWork.CuratorRepository.CreateNew();
                    user.Role = RoleType.Curator;
                    user.ApplicationUserId = applicationUser.Id;
                    user.ApplicationUser = applicationUser;
                    user.Email = model.Email;
                    user.About = model.About;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    break;
                case "deanery":
                    user = _unitOfWork.DeaneryRepository.CreateNew();
                    user.Role = RoleType.Deanery;
                    user.ApplicationUserId = applicationUser.Id;
                    user.ApplicationUser = applicationUser;
                    user.Email = model.Email;
                    user.About = model.About;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    break;
                //admin по дефолту
                default:
                    user = _unitOfWork.UserRepository.CreateNew();
                    user.Role = RoleType.Admin;
                    user.ApplicationUserId = applicationUser.Id;
                    user.ApplicationUser = applicationUser;
                    user.Email = model.Email;
                    user.About = model.About;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    break;
            }
            
            
            _unitOfWork.Save();
        }
    }
}