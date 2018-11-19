namespace DAL.Repository
{
    using Entity;

    public sealed class ProducerRepository : BaseRepository<Producer>
    {
        public ProducerRepository() : base()
        {
            GetAllItems();
        }
    }
}
