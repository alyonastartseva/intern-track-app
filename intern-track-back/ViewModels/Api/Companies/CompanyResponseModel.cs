namespace intern_track_back.ViewModels.Api.Companies
{
    public class CompanyResponseModel
    {
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Текстовая информация о компании, которую она предоставила
        /// </summary>
        public string? About { get; set; }

        /// <summary>
        /// Географический адрес компании
        /// </summary>
        public string? Address { get; set; }
    }
}
