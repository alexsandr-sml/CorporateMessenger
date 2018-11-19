using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DAL.Entity;

namespace Logic.Managers
{
    public class CustomerManager : BaseManager<Customer>
    {
        protected override List<Customer> getItems()
        {
            return DataManager.Instanse.Customers.GetAllItems();
        }

        protected override void DataProcessing(Customer item)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(item.CustomerFullName));
            Contract.Requires(!string.IsNullOrWhiteSpace(item.CustomerShortName));
        }

        protected override void addItem(Customer item)
        {
            DataManager.Instanse.Customers.Add(item);
        }

        protected override void editItem(Customer item)
        {
            DataManager.Instanse.Customers.Edit(item);
        }

        protected override void deleteItem(Customer item)
        {
            DataManager.Instanse.Customers.Delete(item);
        }
    }
}
