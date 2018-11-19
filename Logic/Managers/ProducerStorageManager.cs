namespace Logic.Managers
{
    using System.Collections.Generic;

    using DAL;
    using DAL.Entity;

    public class ProducerStorageManager : BaseManager<ProducerStorage>
    {
        protected override List<ProducerStorage> getItems()
        {
            return DataManager.Instanse.ProducersStorage.GetAllItems();
        }

        protected override void addItem(ProducerStorage item)
        {
            DataManager.Instanse.ProducersStorage.Add(item);
        }

        protected override void editItem(ProducerStorage item)
        {
            DataManager.Instanse.ProducersStorage.Edit(item);
        }

        protected override void deleteItem(ProducerStorage item)
        {
            DataManager.Instanse.ProducersStorage.Delete(item);
        }
    }
}
