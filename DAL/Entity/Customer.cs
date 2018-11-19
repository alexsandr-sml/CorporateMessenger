namespace DAL.Entity
{
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class Customer : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Полное наименование
        /// </summary>
        [DisplayName("Полное наименование")]
        [SaveFieldToDB(Enable = true)]
        public string CustomerFullName { get; set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        [DisplayName("Краткое наименование")]
        [SaveFieldToDB(Enable = true)]
        public string CustomerShortName { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [DisplayName("Адрес")]
        [SaveFieldToDB(Enable = true)]
        public string Adress { get; set; }

        /// <summary>
        /// эл. адрес
        /// </summary>
        [DisplayName("E-mail")]
        [SaveFieldToDB(Enable = true)]
        public string Email { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [DisplayName("Должность контактного лица")]
        [SaveFieldToDB(Enable = true)]
        public string PostContactPerson { get; set; }

        /// <summary>
        /// ФИО контактного лица
        /// </summary>
        [DisplayName("ФИО контактного лица")]
        [SaveFieldToDB(Enable = true)]
        public string FullNameContactPerson { get; set; }

        /// <summary>
        /// Телефон контактного лица
        /// </summary>
        [DisplayName("Телефон контактного лица")]
        [SaveFieldToDB(Enable = true)]
        public string PhoneContactPerson { get; set; }

        /// <summary>
        /// ФИО руководителя
        /// </summary>
        [DisplayName("ФИО руководителя")]
        [SaveFieldToDB(Enable = true)]
        public string FullNameHead { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [DisplayName("Телефон руководителя")]
        [SaveFieldToDB(Enable = true)]
        public string PhoneHead { get; set; }

        public override string ToString()
        {
            return CustomerShortName ?? "-";
        }
    }
}
