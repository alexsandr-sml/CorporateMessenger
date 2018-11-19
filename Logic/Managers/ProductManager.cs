namespace Logic.Managers
{
    using System;
    using System.Collections.Generic;

    using DAL;
    using DAL.Entity;

    public class ProductManager : BaseManager<Product>
    {
        protected override List<Product> getItems()
        {
            return DataManager.Instanse.Products.GetAllItems();
        }

        protected override void DataProcessing(Product item)
        {
            Check(item);
            base.DataProcessing(item);
        }

        protected override void addItem(Product item)
        {
            DataManager.Instanse.Products.Add(item);
        }

        protected override void editItem(Product item)
        {
            DataManager.Instanse.Products.Edit(item);
        }

        protected override void deleteItem(Product item)
        {
            DataManager.Instanse.Products.Delete(item);
        }

        private void Check(Product item)
        {
            if(item.CategoryId <= 0)
                throw new Exception("Ошибка! Не указана категория!");

            if(item.UnitId <= 0)
                throw new Exception("Ошибка! Не указана единица измерения!");

        }
    }
}
