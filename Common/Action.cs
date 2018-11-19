using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    /// <summary>
    /// Задает идентификаторы, которые определяют тип операции
    /// </summary>
    public enum ActionEnum
    {
        
        /// <summary>
        /// Добавление 
        /// </summary>
        Add = 0,
        /// <summary>
        /// Редактирование
        /// </summary>
        Edit = 1,
        /// <summary>
        /// Удаление
        /// </summary>
        Delete = 2,
        /// <summary>
        /// Просмотр
        /// </summary>
        View = 3
    }
}
