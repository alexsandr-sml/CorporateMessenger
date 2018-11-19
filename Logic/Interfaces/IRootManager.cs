using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL.Interfaces;

namespace Logic.Interfaces
{
    public interface IRootManager<T> where T : IDbEntity, new()
    {
        /// <summary>
        /// Получить все элементы
        /// </summary>
        Func<List<T>> GetItems { get; }

        /// <summary>
        /// Редактирование элемента
        /// </summary>
        /// <param name="item"></param>
        Action<T> SaveItem { get; }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="item"></param>
        Action<T> DeleteItem { get; }
    }
}
