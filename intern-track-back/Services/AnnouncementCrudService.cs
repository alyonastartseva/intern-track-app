using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intern_track_back.Data;
using intern_track_back.ViewModels.Api.Announcements.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Services
{
    public class AnnouncementCrudService
    {
        private readonly UnitOfWork _unitOfWork;

        public AnnouncementCrudService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult<int> CreateOrUpdate(AnnouncementRequestModel model)
        {
            var result = model.Id > 0
                ? Update(model)
                : Create(model);

            return result;
        }

        private ActionResult<int> Create(AnnouncementRequestModel model)
        {
            //todo добавить проверку на права! (по роли)
            
            var announcement = _unitOfWork.AnnouncementRepository.CreateNew();
            
            announcement.Title = model.Title;
            announcement.Text = model.Text;
            
            _unitOfWork.Save();

            return new ActionResult<int>(announcement.Id);
        }   

        private ActionResult<int> Update(AnnouncementRequestModel model)
        {
            //todo добавить проверку на права! (по создателю и админу)

            var announcement = _unitOfWork.AnnouncementRepository
                .FirstOrDefault(a => a.Id == model.Id);

            if (announcement == null)
            {
                return new ActionResult<int>(new NotFoundResult());
            }
            
            announcement.Title = model.Title;
            announcement.Text = model.Text;
            
            _unitOfWork.Save();
            return new ActionResult<int>(announcement.Id);
        }

        public IActionResult Remove(int id)
        {
            //todo добавить проверку на права! (по создателю и админу)
            
            var announcement = _unitOfWork.AnnouncementRepository
                .FirstOrDefault(a => a.Id == id);

            if (announcement == null)
            {
                return new NotFoundResult();
            }
            
            _unitOfWork.AnnouncementRepository.Remove(announcement);
            
            _unitOfWork.Save();
            return new OkResult();
        }
    }
}