namespace DAL.Entity
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Interfaces;
    using Attributes;

    public class ClientVersion : IDbEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        /// <summary>
        /// главный номер версии
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Major { get; set; }

        /// <summary>
        ///  вспомогательный номер версии
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Minor { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Путь к обновлению
        /// </summary>
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string Path { get; set; }
    }
}
