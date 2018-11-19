namespace DAL.Repository
{
    using Entity;

    public sealed class CustomerRepository :  BaseRepository<Customer>
    {
        public CustomerRepository() : base()
        {
            GetAllItems();
        }
    }
}
