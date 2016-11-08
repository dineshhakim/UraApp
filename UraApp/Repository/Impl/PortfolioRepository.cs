using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;

namespace UraApp.Repository.Impl
{
    public class PortfolioRepository : RepositoryBase<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

       
    }
}
