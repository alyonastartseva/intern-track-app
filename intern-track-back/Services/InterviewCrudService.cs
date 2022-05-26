using intern_track_back.Data;

namespace intern_track_back.Services
{
    public class InterviewCrudService
    {
        private readonly UnitOfWork _unitOfWork;

        public InterviewCrudService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}