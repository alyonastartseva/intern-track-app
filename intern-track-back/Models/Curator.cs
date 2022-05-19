using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Curator : User
    {
        /// <summary>
        /// Подопечные у куратора
        /// </summary>
        public ICollection<User> Mentee { get; set; }
    }
}