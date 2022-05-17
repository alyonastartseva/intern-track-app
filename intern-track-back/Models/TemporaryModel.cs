using System;
using System.Collections.Generic;

namespace intern_track_back.Models
{
    public class TemporaryModel
    {
        #region Параметры, существующие во всех моделях

        public int Id { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime ModifyDateTime { get; set; }

        #endregion

        #region User (думаю, что это попадет в ApplicationUser)

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Текстовая информация о пользователе, которую он предоставил
        /// </summary>
        public string About { get; set; }
        
        /// <summary>
        /// Контакты, способы связи с пользователем
        /// </summary>
        public ICollection<string> Contacts { get; set; }

        #endregion

        #region CV - что это вообще?

        //всё как в Vacancy

        #endregion
        
        
        // Прочее:
        // Нужно не забыть отнаследовать пользователей
        // Делать ли роли?? Так то да, надо, отдельный енам с ними надо
    }
}