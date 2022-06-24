namespace intern_track_back.ViewModels.Api.Students
{
    public class StudentResponseModel
    {
        public int StudentId { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Текстовая информация о пользователе, которую он предоставил
        /// </summary>
        public string? About { get; set; }
        
        /// <summary>
        /// Номер курса обучения
        /// </summary>
        public int Course { get; set; }
        
        /// <summary>
        /// Статус активности студента в игре "попади на работу", что он уже сделал
        /// </summary>
        public string GeneralStudentStatus { get; set; }
    }
}