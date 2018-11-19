namespace Logic.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL;
    using DAL.Entity;

    public class PriceListManager : BaseManager<PriceList>
    {
        protected override List<PriceList> getItems()
        {
            return DataManager.Instanse.PriceLists.GetAllItems();
        }

        protected override void addItem(PriceList item)
        {
            item.Number = 1;
            var _pricelists = DataManager.Instanse.PriceLists.GetAllItems().Where(pl => pl.DateCreate.Date == item.DateCreate.Date).ToList();
            if (_pricelists.Count > 0)
            {
                item.Number = _pricelists.Max(pl => pl.Number) + 1;
            }

            item.UID = string.Format($"{item.Number}/{item.DateCreate.Date.ToShortDateString()}");
            DataManager.Instanse.PriceLists.Add(item);
        }

        protected override void editItem(PriceList item)
        {
            DataManager.Instanse.PriceLists.Edit(item);
        }

        protected override void deleteItem(PriceList item)
        {
            foreach (var element in item.ProductPositions)
            {
                DataManager.Instanse.ProductPositions.Delete(element);
            }

            DataManager.Instanse.PriceLists.Delete(item);
        }
    }
}
