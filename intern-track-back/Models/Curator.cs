using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Curator : User
    {
        /// <summary>
        /// Подопечные у куратора
        /// </summary>
        public ICollection<ApplicationUser> Mentee { get; set; }
    }
}