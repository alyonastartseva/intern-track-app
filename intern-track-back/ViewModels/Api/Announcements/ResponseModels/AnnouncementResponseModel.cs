using System;
using System.Linq;
using intern_track_back.Data;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.ViewModels.Api.Announcements.ResponseModels
{
    public class AnnouncementResponseModel
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Text { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public AnnouncementResponseModel Init(int id, UnitOfWork unitOfWork)
        {
            var announcement = unitOfWork.AnnouncementRepository
                .FirstOrDefault(a => a.Id == id);
            
            if (announcement == null)
            {
                return this;
            }

            Title = announcement.Title;
            Text = announcement.Text;
            CreateDateTime = announcement.CreateDateTime;
            ModifyDateTime = announcement.ModifyDateTime;

            return this;
        }
    }
}