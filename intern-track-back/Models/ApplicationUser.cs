using Microsoft.AspNetCore.Identity;

namespace intern_track_back.Models
{
    /// <summary>
    /// Сущность пользователя, основанная на IdentityUser. 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
