using intern_track_back.Enumerations;

namespace intern_track_back.ViewModels.Api.Users.ResponseModels
{
    public class UserResponseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }

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
        /// Роль
        /// </summary>
        public RoleType Role { get; set; }

        /// <summary>
        /// Номер курса обучения
        /// </summary>
        public int Course { get; set; }

        /// <summary>
        /// Географический адрес компании
        /// </summary>
        public string? CompanyAddress { get; set; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Географический адрес деканата
        /// </summary>
        public string? DeaneryAddress { get; set; }
    }
}
