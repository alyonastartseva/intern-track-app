using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class Curator
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Подопечные у куратора
        /// </summary>
        public ICollection<ApplicationUser> Mentee { get; set; }
    }
}