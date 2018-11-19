namespace Logic.Managers
{
    using System.Collections.Generic;

    using Common;
    using DAL;
    using DAL.Entity;
    
    public class UserManager : BaseManager<User>
    {
        protected override List<User> getItems()
        {
            return DataManager.Instanse.Users.GetAllItems();
        }

        protected override void DataProcessing(User item)
        {
            item.Hash = item.Password.CalculateMD5Hash();
        }

        protected override void addItem(User item)
        {
            DataManager.Instanse.Users.Add(item);
        }

        protected override void editItem(User item)
        {
            DataManager.Instanse.Users.Edit(item);
        }

        protected override void deleteItem(User item)
        {
            DataManager.Instanse.Users.Delete(item);
        }
    }
}
