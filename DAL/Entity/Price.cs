namespace DAL.Entity
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Interfaces;
    using Attributes;

    [DisplayName("Цена")]
    public sealed class Price : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public ProducerStorage ProducerStorageObject
        {
            get
            {
                return DataManager.Instanse.ProducersStorage.GetAllItems().FirstOrDefault(ps => ps.PriceId == Id);
            }
        }

        /// <summary>
        /// Наименование
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public string ProductString
        {
            get
            {
                return ProducerStorageObject?.ProductObject?.NameProduct;
            }
        }

        /// <summary>
        /// Наименование
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public string ProducerString
        {
            get
            {
                return ProducerStorageObject?.ProducerObject?.ProducerShortName;
            }
        }

        /// <summary>
        /// Цена
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public double Cost { get; set; }

        /// <summary>
        /// Добавленная стоимость
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public double AdditionalCost { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public DateTime DateAdding { get; set; }

        public override string ToString()
        {
            return Cost.ToString() + " (" + AdditionalCost + ")";
        }
    }
}