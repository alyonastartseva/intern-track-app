using intern_track_back.Models;

namespace intern_track_back.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с текущим пользователем
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Получить сущность текущего пользователя
        /// </summary>
        User GetCurrent();
    }
}