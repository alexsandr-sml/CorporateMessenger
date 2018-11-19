namespace DAL.Repository
{
    using Entity;

    public sealed class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository() : base()
        {
            GetAllItems();
        }
    }
}
