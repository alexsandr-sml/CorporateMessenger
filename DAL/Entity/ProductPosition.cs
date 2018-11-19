namespace DAL.Entity
{
    using System;
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class ProductPosition : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Id прайс-листа
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int PriceListId { get; set; }

        /// <summary>
        /// Позиция в списке
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int TopPosition { get; set; }

        /// <summary>
        /// Id продукта на складе
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int ProducerStorageId { get; set; }

        /// <summary>
        /// Продукт на складе
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public ProducerStorage ProducerStorageObject
        {
            get
            {
                return DataManager.Instanse.ProducersStorage.GetItemFromID(ProducerStorageId);
            }
        }

        /// <summary>
        /// Наименование продукта
        /// </summary>
        [DisplayName("Наименование товара")]
        [SaveFieldToDB(Enable = false)]
        public string ProductName
        {
            get
            {
                return ProducerStorageObject?.ProductObject?.NameProduct;
            }
        }

        /// <summary>
        /// Количество
        /// </summary>
        [DisplayName("Количество")]
        [SaveFieldToDB(Enable = true)]
        public double Count { get; set; }

        /// <summary>
        /// Ед. измерения
        /// </summary>
        [DisplayName("Ед. измерения")]
        [SaveFieldToDB(Enable = true)]
        public string Unit { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [DisplayName("Стоимость за ед. без НДС, тенге")]
        [SaveFieldToDB(Enable = true)]
        public double Cost { get; set; }


        /// <summary>
        /// Сумма НДС
        /// </summary>
        [DisplayName("Величина НДС, тенге")]
        [SaveFieldToDB(Enable = true)]
        public double AdditionalCost { get; set; }

        /// <summary>
        /// Итоговая сумма НДС
        /// </summary>
        [DisplayName("Итоговая сумма без НДС, тенге")]
        [SaveFieldToDB(Enable = false)]
        public double TotalSumm
        {
            get
            {
                return Count* Cost;
            }
        }

        /// <summary>
        /// Итоговая сумма НДС
        /// </summary>
        [DisplayName("Итоговая сумма c НДС, тенге")]
        [SaveFieldToDB(Enable = false)]
        public double TotalAdditionalSumm
        {
            get
            {
                return Count * AdditionalCost;
            }
        }
    }
}
