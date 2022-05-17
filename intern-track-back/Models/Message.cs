using System;

namespace intern_track_back.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }
        
        /// <summary>
        /// Отправитель сообщения
        /// </summary>
        public ApplicationUser Sender { get; set; }
        
        /// <summary>
        /// Получатель сообщения
        /// </summary>
        public ApplicationUser Receiver { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
        
        //Attachment : File
    }
}