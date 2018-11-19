namespace Logic.Managers
{
    using System.Collections.Generic;

    using DAL;
    using DAL.Entity;

    public class CategoryManager : BaseManager<Category>
    {
        protected override List<Category> getItems()
        {
            return DataManager.Instanse.Categories.GetAllItems();
        }

        protected override void addItem(Category item)
        {
            DataManager.Instanse.Categories.Add(item);
        }

        protected override void editItem(Category item)
        {
            DataManager.Instanse.Categories.Edit(item);
        }

        protected override void deleteItem(Category item)
        {
            DataManager.Instanse.Categories.Delete(item);
        }
    }
}
