namespace DAL.Repository
{
    using Entity;

    public sealed class PriceListStateRepository : BaseRepository<PriceListState>
    {
        public PriceListStateRepository() : base()
        {
            GetAllItems();
        }
    }
}
