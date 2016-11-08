using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;


namespace UraApp.Repository.Impl
{
    public class RoleTypeRepository : RepositoryBase<RoleType>, IRoleTypeRepository
    {
        public RoleTypeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
    }
}
}
