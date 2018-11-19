namespace Logic.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DAL;
    using DAL.Entity;

    public class ProducerManager : BaseManager<Producer>
    {
        protected override List<Producer> getItems()
        {
            return DataManager.Instanse.Producers.GetAllItems();
        }

        protected override void addItem(Producer item)
        {
            DataManager.Instanse.Producers.Add(item);
        }

        protected override void editItem(Producer item)
        {
            DataManager.Instanse.Producers.Edit(item);
        }

        protected override void deleteItem(Producer item)
        {
            DataManager.Instanse.Producers.Delete(item);
        }
    }
}
