using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DAL.Entity;

namespace Logic.Managers
{
    public class UnitManager : BaseManager<Unit>
    {
        protected override List<Unit> getItems()
        {
            return DataManager.Instanse.Units.GetAllItems();
        }

        protected override void addItem(Unit item)
        {
            DataManager.Instanse.Units.Add(item);
        }

        protected override void editItem(Unit item)
        {
            DataManager.Instanse.Units.Edit(item);
        }

        protected override void deleteItem(Unit item)
        {
            DataManager.Instanse.Units.Delete(item);
        }
    }
}
