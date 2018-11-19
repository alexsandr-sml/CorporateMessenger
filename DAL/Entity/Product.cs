namespace DAL.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Interfaces;
    using Attributes;

    public sealed class Product : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// Id категории
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public Category Categoryobject
        {
            get
            {
                return DataManager.Instanse.Categories.GetItemFromID(CategoryId);
            }
        }

        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Наименование")]
        [SaveFieldToDB(Enable = true)]
        public string NameProduct { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Описание")]
        [SaveFieldToDB(Enable = true)]
        public string Description { get; set; }

        /// <summary>
        /// Id единицы измерения
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int UnitId { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        [DisplayName("Единица измерения")]
        [SaveFieldToDB(Enable = false)]
        public Unit UnitObject
        {
            get
            {
                return DataManager.Instanse.Units.GetItemFromID(UnitId);
            }
        }

        /// <summary>
        /// Поставщик
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public List<ProducerStorage> ProducersObject
        {
            get
            {
                return DataManager.Instanse.ProducersStorage.GetAllItems().Where(ps => ps.ProductId == Id).ToList();
            }
        }

        public override string ToString()
        {
            return NameProduct;
        }
    }
}
