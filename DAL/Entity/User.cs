namespace DAL.Entity
{
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class User : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Имя пользователя")]
        [SaveFieldToDB(Enable = true)]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public string Password { get; set; }

        /// <summary>
        /// ID сотрудника
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        [DisplayName("Сотрудник")]
        [SaveFieldToDB(Enable = false)]
        public Employee EmployeeObject
        {
            get
            {
                return DataManager.Instanse.Employees.GetItemFromID(EmployeeId);
            }
        }

        /// <summary>
        /// Хэш
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string Hash { get; set; }
    }
}
