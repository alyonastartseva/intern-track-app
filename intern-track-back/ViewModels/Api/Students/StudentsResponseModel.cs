using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;
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
                    GeneralStudentStatus = s.GeneralStudentStatus != 0 ? s.GeneralStudentStatus.GetDisplayName() : ""
                })
                .OrderBy(v => v.LastName)
                .ToList();

            return this;
        }
    }
}