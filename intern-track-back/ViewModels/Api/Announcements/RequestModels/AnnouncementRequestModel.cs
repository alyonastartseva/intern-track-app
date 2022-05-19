using System.Linq;
using intern_track_back.Data;

namespace intern_track_back.ViewModels.Api.Announcements.RequestModels
{
    public class AnnouncementRequestModel
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Text { get; set; }

        public AnnouncementRequestModel Init(int id, UnitOfWork unitOfWork)
        {
            var announcement = unitOfWork.AnnouncementRepository
                .FirstOrDefault(a => a.Id == id);
            
            if (announcement == null)
            {
                return this;
            }

            Id = id;
            Title = announcement.Title;
            Text = announcement.Text;

            return this;
        }
    }
}