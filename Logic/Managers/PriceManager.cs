namespace Logic.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL;
    using DAL.Entity;

    public class PriceManager : BaseManager<Price>
    {
        protected override List<Price> getItems()
        {
            return DataManager.Instanse.Prices.GetAllItems();
        }

        protected override void addItem(Price item)
        {
            DataManager.Instanse.Prices.Add(item);
        }

        protected override void editItem(Price item)
        {
            DataManager.Instanse.Prices.Edit(item);
        }

        protected override void deleteItem(Price item)
        {
            DataManager.Instanse.Prices.Delete(item);
        }
    }
}
