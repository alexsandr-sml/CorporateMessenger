namespace DAL.Entity
{
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    [DisplayName("Учетная запись")]
    public sealed class Account : IDbEntity
    {
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }
    }
}
