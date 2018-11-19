namespace DAL.Repository
{
    using Entity;

    public sealed class UnitRepository : BaseRepository<Unit>
    {
        public UnitRepository() : base()
        {
            GetAllItems();
        }
    }
}
