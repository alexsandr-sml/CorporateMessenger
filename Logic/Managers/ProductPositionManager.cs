namespace Logic.Managers
{
    using System.Collections.Generic;

    using DAL;
    using DAL.Entity;

    public class ProductPositionManager : BaseManager<ProductPosition>
    {
        protected override List<ProductPosition> getItems()
        {
            return DataManager.Instanse.ProductPositions.GetAllItems();
        }

        protected override void addItem(ProductPosition item)
        {
            DataManager.Instanse.ProductPositions.Add(item);
        }

        protected override void editItem(ProductPosition item)
        {
            DataManager.Instanse.ProductPositions.Edit(item);
        }

        protected override void deleteItem(ProductPosition item)
        {
            DataManager.Instanse.ProductPositions.Delete(item);
        }
    }
}
