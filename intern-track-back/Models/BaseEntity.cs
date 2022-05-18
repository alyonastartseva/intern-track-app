using System;

namespace intern_track_back.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
    }
}