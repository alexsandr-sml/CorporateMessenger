namespace DAL.Repository
{
    using Entity;

    public class ClientVersionRepository : BaseRepository<ClientVersion>
    {
        public ClientVersionRepository() : base()
        {
            GetAllItems();
        }
    }
}
