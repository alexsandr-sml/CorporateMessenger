namespace DAL.Repository
{
    using Entity;

    public sealed class ProductPositionRepository : BaseRepository<ProductPosition>
    {
        public ProductPositionRepository() : base()
        {
            GetAllItems();
        }
    }
}
