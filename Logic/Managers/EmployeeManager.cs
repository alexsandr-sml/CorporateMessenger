namespace Logic.Managers
{
    using System.Collections.Generic;

    using DAL;
    using DAL.Entity;

    public class EmployeeManager : BaseManager<Employee>
    {
        protected override List<Employee> getItems()
        {
            return DataManager.Instanse.Employees.GetAllItems();
        }

        protected override void addItem(Employee item)
        {
            DataManager.Instanse.Employees.Add(item);
        }

        protected override void editItem(Employee item)
        {
            DataManager.Instanse.Employees.Edit(item);
        }

        protected override void deleteItem(Employee item)
        {
            DataManager.Instanse.Employees.Delete(item);
        }
    }
}
