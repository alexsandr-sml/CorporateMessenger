namespace DAL.Repository
{
    using Entity;

    public sealed class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository() : base()
        {
            GetAllItems();
        }
    }
}
