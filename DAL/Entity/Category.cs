namespace DAL.Entity
{
    using System.ComponentModel;

    using Interfaces;
    using Attributes;

    public sealed class Category : IDbEntity
    {
        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        [SaveFieldToDB(Enable = true)]
        public string NameCategory { get; set; }

        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public string Description { get; set; }

        [Browsable(false)]
        [SaveFieldToDB(Enable = true)]
        public int RootCategoryId { get; set; }

        [Browsable(false)]
        [SaveFieldToDB(Enable = false)]
        public Category Root
        {
            get
            {
                return DataManager.Instanse.Categories.GetItemFromID(RootCategoryId);
            }
        }

        [DisplayName("Тип категории")]
        [SaveFieldToDB(Enable = false)]
        public string TypeCategory
        {
            get
            {
                return RootCategoryId == 0 ? "Родительская" : ""; 
            }
        }

        public override string ToString()
        {
            return NameCategory ?? "-";
        }
    }
}
