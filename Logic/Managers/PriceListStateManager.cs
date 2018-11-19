namespace Logic.Managers
{
    using System.Collections.Generic;

    using DAL;
    using DAL.Entity;

    public class PriceListStateManager : BaseManager<PriceListState>
    {
        protected override List<PriceListState> getItems()
        {
            return DataManager.Instanse.PriceListStates.GetAllItems();
        }

        protected override void addItem(PriceListState item)
        {
            DataManager.Instanse.PriceListStates.Add(item);
        }

        protected override void editItem(PriceListState item)
        {
            DataManager.Instanse.PriceListStates.Edit(item);
        }

        protected override void deleteItem(PriceListState item)
        {
            DataManager.Instanse.PriceListStates.Delete(item);
        }
    }
}
