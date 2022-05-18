using System;

namespace intern_track_back.Models
{
    public class Message : BaseEntity
    {
        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public int SenderId { get; set; }
        
        /// <summary>
        /// Отправитель сообщения
        /// </summary>
        public ApplicationUser Sender { get; set; }
        
        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public int ReceiverId { get; set; }
        
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