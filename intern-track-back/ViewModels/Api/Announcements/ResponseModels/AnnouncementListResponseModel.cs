using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;

namespace intern_track_back.ViewModels.Api.Announcements.ResponseModels
{
    public class AnnouncementListResponseModel
    {
        public ICollection<AnnouncementResponseModel> Models { get; set; }

        public AnnouncementListResponseModel Init(UnitOfWork unitOfWork)
        {
            Models = unitOfWork.AnnouncementRepository
                .Select(a => new AnnouncementResponseModel
                {
                    Title = a.Title,
                    Text = a.Text,
                    CreateDateTime = a.CreateDateTime,
                    ModifyDateTime = a.ModifyDateTime
                })
                .OrderBy(m => m.CreateDateTime)
                .ToList();
            
            return this;
        }
    }
}