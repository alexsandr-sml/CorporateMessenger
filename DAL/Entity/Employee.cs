namespace DAL.Entity
{
    using System.ComponentModel;
    using System.Linq;

    using Interfaces;
    using Attributes;

    public sealed class Employee : IDbEntity
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
        [DisplayName("Фамилия")]
        [SaveFieldToDB(Enable = true)]
        public string Family { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Имя")]
        [SaveFieldToDB(Enable = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Отчество")]
        [SaveFieldToDB(Enable = true)]
        public string SecondName { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Должность")]
        [SaveFieldToDB(Enable = true)]
        public string Post { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string Phone { get; set; }

        /// <summary>
        /// Внутренний телефон
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string InternalPhone { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string Email { get; set; }

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Признак, что сотрудник работает
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public bool IsWork { get; set; } = true;
        
        public override string ToString()
        {
            return Family + " " + FirstName?.FirstOrDefault() + ". " + SecondName?.FirstOrDefault() + ". - " + Post;
        }
    }
}
