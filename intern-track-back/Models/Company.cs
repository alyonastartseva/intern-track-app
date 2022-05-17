using System;

namespace intern_track_back.Models
{
    public class Company
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Адрес компании (реальный? имейл? что имелось ввиду)
        /// </summary>
        public string Address { get; set; }
    }
}