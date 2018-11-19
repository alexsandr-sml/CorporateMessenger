namespace DAL.Repository
{
    using Entity;

    public sealed class PriceListRepository : BaseRepository<PriceList>
    {
        public PriceListRepository() : base()
        {
            GetAllItems();
        }
    }
}
