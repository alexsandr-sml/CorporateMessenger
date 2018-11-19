namespace DAL.Entity
{
    using System;
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class ProducerStorage : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int ProductId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Наименование")]
        [SaveFieldToDB(Enable = false)]
        public Product ProductObject
        {
            get
            {
                return DataManager.Instanse.Products.GetItemFromID(ProductId);
            }
        }

        /// <summary>
        /// Id поставщика
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int ProducerId { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        [DisplayName("Поставщик")]
        [SaveFieldToDB(Enable = false)]
        public Producer ProducerObject
        {
            get
            {
                return DataManager.Instanse.Producers.GetItemFromID(ProducerId);
            }
        }

        /// <summary>
        /// Id цены
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int PriceId { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [DisplayName("Цена")]
        [SaveFieldToDB(Enable = false)]
        public Price PriceObject
        {
            get
            {
                return DataManager.Instanse.Prices.GetItemFromID(PriceId);
            }
        }

        /// <summary>
        /// Количество
        /// </summary>
        [DisplayName("Дата последнего обновления")]
        [SaveFieldToDB(Enable = true)]
        public DateTime LastUpdate { get; set; }
    }
}
