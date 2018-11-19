namespace DAL.Entity
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Interfaces;
    using Attributes;

    public sealed class PriceListState : IDbEntity
    {

        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }


        /// <summary>
        /// Id
        /// </summary>
        [DisplayName("Наименование")]
        [SaveFieldToDB(Enable = true)]
        public string Name { get; set; }


        /// <summary>
        /// Связанный с данным статусом делегат
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public Action Process { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
