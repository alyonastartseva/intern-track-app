using System.ComponentModel.DataAnnotations.Schema;
using intern_track_back.Enumerations;

namespace intern_track_back.Models
{
    /// <summary>
    /// Сущность гостя. Ее возвращает CurrentUserService.GetCurrent(), если текущий пользователь не авторизован.
    /// </summary>
    [NotMapped]
    public class Guest : User
    {
        public Guest()
        {
            Name = "Гость";
            Role = RoleType.Guest;
        }
    }
}