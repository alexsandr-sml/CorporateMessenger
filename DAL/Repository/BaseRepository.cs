namespace DAL.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Data;

    using Interfaces;
    using Attributes;

    public abstract class BaseRepository<T> where T : IDbEntity, new()
    {
        protected List<T> list;
        protected string TableName { get; set; }

        public DataManager ParentDataManager { get; set; }
        public BaseRepository()
        {
            var type = typeof(T);
            TableName = type.Name;
        }

        /// <summary>
        /// Возвращает true при успешном добавлении объекта в базу данных
        /// </summary>
        /// <param name="item">Добавляемый объект</param>
        /// <returns>bool</returns>
        public virtual bool Add(T item)
        {
            var type = typeof(T);
            var parameters = new List<object>();
            foreach (var propertyInfo in type.GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttributes(typeof(SaveFieldToDBAttribute), true).FirstOrDefault(a => a is SaveFieldToDBAttribute) as SaveFieldToDBAttribute;
                if (attribute != null && attribute.Enable == false)
                    continue;

                parameters.Add(propertyInfo.Name);
                parameters.Add(propertyInfo.GetValue(item, null));
            }
            var id = DataManager.Instanse.SqlTools.InsertIntoTable(TableName, parameters);
            if (id > 0)
            {
                item.Id = id;
                if (list != null)
                    list.Add(item);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Возвращает true при успешном удалении объекта в базу данных
        /// </summary>
        /// <param name="item">Удаляемый объект</param>
        /// <returns>bool</returns>
        public virtual bool Delete(T item)
        {
            var type = typeof(T);
            var parameters = new List<object>();

            foreach (var propertyInfo in type.GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttributes(typeof(SaveFieldToDBAttribute), true).FirstOrDefault(a => a is SaveFieldToDBAttribute) as SaveFieldToDBAttribute;
                if (attribute != null && attribute.Enable == false)
                    continue;

                parameters.Add(propertyInfo.Name);
                parameters.Add(propertyInfo.GetValue(item, null));
            }

            if (DataManager.Instanse.SqlTools.DeleteFromTable(this.TableName, parameters) > 0)
            {
                if (list != null)
                    list.RemoveAll(d => d.Id == item.Id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Возвращает true при успешном изменении объекта в базе данных
        /// </summary>
        /// <param name="item">Объект</param>
        /// <returns>bool</returns>
        public virtual bool Edit(T item)
        {
            var type = typeof(T);
            var parameters = new List<object>();

            foreach (var propertyInfo in type.GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttributes(typeof(SaveFieldToDBAttribute), true).FirstOrDefault(a => a is SaveFieldToDBAttribute) as SaveFieldToDBAttribute;
                if (attribute != null && attribute.Enable == false)
                    continue;

                parameters.Add(propertyInfo.Name);
                parameters.Add(propertyInfo.GetValue(item, null));
            }

            if (DataManager.Instanse.SqlTools.EditItems(TableName, parameters) > 0)
            {
                var pos = list.FindIndex(d => d.Id == item.Id);
                list[pos] = item;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Возвращает список всех объектов
        /// </summary>
        /// <returns>List</returns>
        public virtual List<T> GetAllItems()
        {
            if (list != null)
                return list;

            var type = typeof(T);
            var table = DataManager.Instanse.SqlTools.GetTable(this.TableName);
            var properties = typeof(T).GetProperties().ToList();
            var result = new List<T>();
            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow((DataRow)row, properties);
                result.Add(item);
            }

            return (list = result);
        }

        /// <summary>
        /// Возвращает объект собранный из DataRow
        /// </summary>
        /// <typeparam name="T">Объект</typeparam>
        /// <param name="row">DataRow</param>
        /// <param name="properties">Параметры объекта T</param>
        /// <returns>T объект</returns>
        private T CreateItemFromRow(DataRow row, IList<PropertyInfo> properties)
        {
            T item = new T();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(SaveFieldToDBAttribute), true).FirstOrDefault(a => a is SaveFieldToDBAttribute) as SaveFieldToDBAttribute;
                if (attribute != null && attribute.Enable == false)
                    continue;

                if (row[property.Name] == DBNull.Value)
                    continue;
                var value = Convert.ChangeType(row[property.Name], property.PropertyType);
                property.SetValue(item, value, null);
            }
            return item;
        }

        /// <summary>
        /// Обновляет список объектов
        /// </summary>
        public virtual void Refresh()
        {

        }

        /// <summary>
        /// Возвращает объект с соответстующим Id
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <returns>Объект</returns>
        public virtual T GetItemFromID(int id)
        {
            return list.FirstOrDefault(e => e.Id == id);
        }

        public virtual T GetItem(T item)
        {
            return default(T);
        }
    }
}
