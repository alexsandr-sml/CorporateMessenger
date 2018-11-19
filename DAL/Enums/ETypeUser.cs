using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enums
{
    public enum ETypeUser : byte
    {
        /// <summary>
        /// Супер пользователь
        /// </summary>
        Root = 0,

        /// <summary>
        /// Администратор
        /// </summary>
        Administrator = 1
    }
}
