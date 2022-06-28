using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
using intern_track_back.Enumerations;
using Microsoft.OpenApi.Extensions;

namespace intern_track_back.ViewModels.Api.Students
{
    public class StudentsResponseModel
    {
        public List<StudentResponseModel>? Students { get; set; }
        
        public StudentsResponseModel Init(UnitOfWork unitOfWork)
        {
            Students = unitOfWork.StudentRepository
                .Select(s => new StudentResponseModel
                {
                    StudentId = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    About = s.About,
                    Course = s.Course,
                    GeneralStudentStatus = s.GeneralStudentStatus == 0 ? "student haven't done anything yet" : GetStudentStatusName(s.GeneralStudentStatus),
                    Email = s.Email
                })
                .OrderBy(v => v.LastName)
                .ToList();

            return this;
        }

        private static string GetStudentStatusName(GeneralStudentStatusType statusType)
        {
            switch (statusType)
            {
                case GeneralStudentStatusType.Waiting:
                    return "Собеседование ожидается";
                case GeneralStudentStatusType.Happened:
                    return "Собеседование пройдено";
                case GeneralStudentStatusType.Denied:
                    return "Отказано";
                case GeneralStudentStatusType.SendOffer:
                    return "Предложение оффера";
                case GeneralStudentStatusType.ConfirmOffer:
                    return "Оффер подтвержден";
            }

            return "";
        }
    }
}