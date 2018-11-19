namespace DAL.Repository
{
    using Entity;

    public sealed class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository() : base()
        {
            GetAllItems();
        }
    }
}
