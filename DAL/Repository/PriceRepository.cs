namespace DAL.Repository
{
    using Entity;

    public sealed class PriceRepository: BaseRepository<Price>
    {
        public PriceRepository() : base()
        {
            GetAllItems();
        }
    }
}
