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
            user.Name = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Course = model.Course;
            user.About = model.About;
            user.Role = RoleType.Student;

            _unitOfWork.Save();
        }

        public void Register(RegisterViewModel model, ApplicationUser applicationUser)
        {
            User user;
            switch (model.Role.ToLower())
            {
                case "company":
                    user = _unitOfWork.CompanyRepository.CreateNew();
                    user.Role = RoleType.Company;
                    break;
                case "curator":
                    user = _unitOfWork.CuratorRepository.CreateNew();
                    user.Role = RoleType.Curator;
                    break;
                case "deanery":
                    user = _unitOfWork.DeaneryRepository.CreateNew();
                    user.Role = RoleType.Deanery;
                    break;
                //admin по дефолту
                default:
                    user = _unitOfWork.UserRepository.CreateNew();
                    user.Role = RoleType.Admin;
                    break;
            }
            
            user.ApplicationUserId = applicationUser.Id;
            user.ApplicationUser = applicationUser;
            user.Name = model.UserName;
            user.About = model.About;
            
            _unitOfWork.Save();
        }
    }
}