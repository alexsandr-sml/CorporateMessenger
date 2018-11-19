namespace DAL.Repository
{
    using Entity;

    public sealed class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository() : base()
        {
            GetAllItems();
        }
    }
}
