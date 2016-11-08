using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UraApp.Repository.Impl
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }


    }
}
