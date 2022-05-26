using intern_track_back.Models;

namespace intern_track_back.ViewModels.Api.Vacancies.ResponseModels
{
    public class VacancyResponseModel
    {
        /// <summary>
        /// Описание вакансии
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Стэк
        /// </summary>
        public string Stack { get; set; }
        
        /// <summary>
        /// Общее количество мест, которое выделила компания
        /// </summary>
        public int TotalNumber { get; set; }
        
        /// <summary>
        /// Количество оставшихся свободных мест
        /// </summary>
        public int FreeNumber { get; set; }
        
        /// <summary>
        /// Компания, опубликовавшая вакансию
        /// </summary>
        public Company Company { get; set; }
    }
}