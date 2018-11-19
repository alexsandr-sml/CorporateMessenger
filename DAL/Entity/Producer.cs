namespace DAL.Entity
{
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    /// <summary>
    /// Поставщик
    /// </summary>
    public sealed class Producer : IDbEntity
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
        public string ProducerFullName { get; set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        [DisplayName("Краткое наименование")]
        [SaveFieldToDB(Enable = true)]
        public string ProducerShortName { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [DisplayName("Адрес")]
        [SaveFieldToDB(Enable = true)]
        public string Adress { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [DisplayName("Телефон")]
        [SaveFieldToDB(Enable = true)]
        public string Phone { get; set; }

        public override string ToString()
        {
            return ProducerShortName;
        }
    }
}
