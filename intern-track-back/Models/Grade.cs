using System;

namespace intern_track_back.Models
{
    public class Grade : BaseEntity
    {
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Значение оуенки по предмету
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Студент, для которого выставлена оценка
        /// </summary>
        public Student Student { get; set; }
        public int StudentId { get; set; }
        
        /// <summary>
        /// Деканат, заполнивший оценку
        /// </summary>
        public Deanery Deanery { get; set; }
        public int DeaneryId { get; set; }
    }
}