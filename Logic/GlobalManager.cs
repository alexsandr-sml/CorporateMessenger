namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic.Managers;
    using Logic.Interfaces;

    using DAL.Interfaces;
    using DAL;

    public sealed class GlobalManager
    {
        const string GLOBAL_PATH = "DataBase\\main.db";

        public GlobalManager()
        {
            Initilization();
        }

        private void Initilization()
        {
            try
            {
                DataManager.Init(GLOBAL_PATH);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private UnitManager _unitManager;
        private CategoryManager _categoryManager;
        private CustomerManager _customerManager;
        private ProducerManager _producerManager;
        private ProductManager _productManager;
        private EmployeeManager _employeeManager;
        private PriceManager _priceManager;
        private ProducerStorageManager _producerStorageManager;
        private UserManager _userManager;
        private ProductPositionManager _productPositionManager;
        private PriceListManager _priceListManager;
        private PriceListStateManager _priceListStateManager;
        private ClientVersionManager _priceListVersionManager;

        public IRootManager<T> GetEntityManager<T>() where T : IDbEntity, new()
        {
            var typename = typeof(T).Name;
            switch (typename)
            {
                case "Unit":
                    return (IRootManager<T>)(_unitManager ?? (_unitManager = new UnitManager()));
                case "Category":
                    return (IRootManager<T>)(_categoryManager ?? (_categoryManager = new CategoryManager()));
                case "Customer":
                    return (IRootManager<T>)(_customerManager ?? (_customerManager = new CustomerManager()));
                case "Producer":
                    return (IRootManager<T>)(_producerManager ?? (_producerManager = new ProducerManager()));
                case "Product":
                    return (IRootManager<T>)(_productManager ?? (_productManager = new ProductManager()));
                case "Employee":
                    return (IRootManager<T>)(_employeeManager ?? (_employeeManager = new EmployeeManager()));
                case "Price":
                    return (IRootManager<T>)(_priceManager ?? (_priceManager = new PriceManager()));
                case "ProducerStorage":
                    return (IRootManager<T>)(_producerStorageManager ?? (_producerStorageManager = new ProducerStorageManager()));
                case "User":
                    return (IRootManager<T>)(_userManager ?? (_userManager = new UserManager()));
                case "ProductPosition":
                    return (IRootManager<T>)(_productPositionManager ?? (_productPositionManager = new ProductPositionManager()));
                case "PriceList":
                    return (IRootManager<T>)(_priceListManager ?? (_priceListManager = new PriceListManager()));
                case "PriceListState":
                    return (IRootManager<T>)(_priceListStateManager ?? (_priceListStateManager = new PriceListStateManager()));
                case "PriceListVersion":
                    return (IRootManager<T>)(_priceListVersionManager ?? (_priceListVersionManager = new ClientVersionManager()));
            }

            throw new Exception("Ошибка! Нет данного менеджера!");
        }
    }
}
