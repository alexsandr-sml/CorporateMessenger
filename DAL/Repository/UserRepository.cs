namespace DAL.Repository
{
    using Entity;

    public sealed class UserRepository : BaseRepository<User>
    {
        public UserRepository() : base ()
        {
            GetAllItems();
        }
    }
}
