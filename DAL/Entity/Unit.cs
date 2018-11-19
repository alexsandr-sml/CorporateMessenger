namespace DAL.Entity
{
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class Unit : IDbEntity
    {
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        [DisplayName("Полное наименование")]
        [SaveFieldToDB(Enable = true)]
        public string FullName { get; set; }

        [DisplayName("Краткое наименование")]
        [SaveFieldToDB(Enable = true)]
        public string ShortName { get; set; }

        [DisplayName("Примечание")]
        [SaveFieldToDB(Enable = true)]
        public string Note { get; set; }

        public override string ToString()
        {
            return FullName ?? ShortName ?? "-";
        }
    }
}
