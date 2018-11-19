using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logic.Interfaces;
using DAL.Interfaces;

namespace Logic.Managers
{
    public class BaseManager<T> : IRootManager<T> where T : IDbEntity, new()
    {
        /// <summary>
        /// Получить все элементы
        /// </summary>
        public Func<List<T>> GetItems
        {
            get
            {
                return getItems;
            }
        }

        /// <summary>
        /// Возвращает элементы
        /// </summary>
        /// <returns></returns>
        protected virtual List<T> getItems()
        {
            return new List<T>();
        }

        /// <summary>
        /// Редактирование элемента
        /// </summary>
        public Action<T> SaveItem
        {
            get
            {
               return Save;
            }
        }

        private void Save(T item)
        {
            DataProcessing(item);

            if (item.Id == 0)
                addItem(item);
            else if (item.Id > 0)
                editItem(item);
            else
                throw new Exception("Ошибка Id меньше 0");
        }
        /// <summary>
        /// Обработка данных
        /// </summary>
        protected virtual void DataProcessing(T item)
        {
            
        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        protected virtual void addItem(T item)
        {

        }

        /// <summary>
        /// Редактирование элемента
        /// </summary>
        /// <param name="item"></param>
        protected virtual void editItem(T item)
        {

        }



        public Action<T> DeleteItem
        {
            get
            {
                return deleteItem;
            }
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="item"></param>
        protected virtual void deleteItem(T item)
        {

        }
    }
}
