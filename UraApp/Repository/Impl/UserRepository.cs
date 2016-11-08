using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;

namespace UraApp.Repository.Impl
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
