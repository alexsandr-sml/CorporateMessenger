namespace DAL
{
    using System;

    using Tools;
    using Repository;

    public sealed class DataManager
    {
        public SQLTools SqlTools;

        public static DataManager Instanse { get; private set; }
        private static bool _isInit = false;

        private DataManager(string dataBaseName)
        {
            SqlTools = new SQLTools(dataBaseName);

            if (!SqlTools.IsServerConnected())
                throw new Exception();
        }    

        public static void Init(string nameDataBase)
        {
            if (_isInit)
                return;

            Instanse = new DataManager(nameDataBase);

            _isInit = true;
        }

        public static void Dispose()
        {
            _isInit = false;
            Instanse = null;
        }

        private AccountRepository _accountRepository;
        public AccountRepository Accounts
        {
            get
            {
                return _accountRepository ?? (_accountRepository = new AccountRepository());
            }
        }

        private UnitRepository _unitRepository;

        public UnitRepository Units
        {
            get
            {
                return _unitRepository ?? (_unitRepository = new UnitRepository());
            }
        }

        private CustomerRepository _customerRepository;

        public CustomerRepository Customers
        {
            get
            {
                return _customerRepository ?? (_customerRepository = new CustomerRepository());
            }
        }

        private ProductRepository _productRepository;

        public ProductRepository Products
        {
            get
            {
                return _productRepository ?? (_productRepository = new ProductRepository());
            }
        }

        private PriceRepository _priceRepository;

        public PriceRepository Prices
        {
            get
            {
                return _priceRepository ?? (_priceRepository = new PriceRepository());
            }
        }

        private CategoryRepository _categoryRepository;

        public CategoryRepository Categories
        {
            get
            {
                return _categoryRepository ?? (_categoryRepository = new CategoryRepository());
            }
        }

        private ProducerRepository _producerRepository;

        public ProducerRepository Producers
        {
            get
            {
                return _producerRepository ?? (_producerRepository = new ProducerRepository());
            }
        }

        private UserRepository _userRepository;

        public UserRepository Users
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository());
            }
        }

        private EmployeeRepository _employeeRepository;

        public EmployeeRepository Employees
        {
            get
            {
                return _employeeRepository ?? (_employeeRepository = new EmployeeRepository());
            }
        }

        private ProducerStorageRepository _producerStorageRepository;

        public ProducerStorageRepository ProducersStorage
        {
            get
            {
                return _producerStorageRepository ?? (_producerStorageRepository = new ProducerStorageRepository());
            }
        }

        private PriceListRepository _priceListRepository;

        public PriceListRepository PriceLists
        {
            get
            {
                return _priceListRepository ?? (_priceListRepository = new PriceListRepository());
            }
        }

        private ProductPositionRepository _productPositionRepository;

        public ProductPositionRepository ProductPositions
        {
            get
            {
                return _productPositionRepository ?? (_productPositionRepository = new ProductPositionRepository());
            }
        }

        private PriceListStateRepository _priceListStateRepository;

        public PriceListStateRepository PriceListStates
        {
            get
            {
                return _priceListStateRepository ?? (_priceListStateRepository = new PriceListStateRepository());
            }
        }

        private ClientVersionRepository _clientVersionRepository;
        public ClientVersionRepository ClientVersions
        {
            get
            {
                return _clientVersionRepository ?? (_clientVersionRepository = new ClientVersionRepository());
            }
        }
    }

}
