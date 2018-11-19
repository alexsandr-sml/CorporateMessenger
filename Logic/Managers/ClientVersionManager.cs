namespace Logic.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DAL;
    using DAL.Entity;

    public class ClientVersionManager : BaseManager<ClientVersion>
    {
        protected override List<ClientVersion> getItems()
        {
            return DataManager.Instanse.ClientVersions.GetAllItems();
        }

        protected override void addItem(ClientVersion item)
        {
            DataManager.Instanse.ClientVersions.Add(item);
        }

        protected override void editItem(ClientVersion item)
        {
            DataManager.Instanse.ClientVersions.Edit(item);
        }

        protected override void deleteItem(ClientVersion item)
        {
            DataManager.Instanse.ClientVersions.Delete(item);
        }
    }
}
