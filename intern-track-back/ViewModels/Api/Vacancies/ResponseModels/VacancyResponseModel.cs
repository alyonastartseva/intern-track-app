using intern_track_back.Models;

namespace intern_track_back.ViewModels.Api.Vacancies.ResponseModels
{
    public class VacancyResponseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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
        /// Компания, опубликовавшая вакансию Id
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Название компаним, опубликовавшей вакансию
        /// </summary>
        public string CompanyName { get; set; }
    }
}