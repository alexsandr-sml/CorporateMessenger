namespace DAL.Repository
{
    using Entity;

    public sealed class ProducerStorageRepository : BaseRepository<ProducerStorage>
    {
        public ProducerStorageRepository() : base()
        {
            GetAllItems();
        }
    }
}
