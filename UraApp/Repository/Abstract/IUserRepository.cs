using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UraApp.Models;
using UraApp.Repository.Infrastructure;

namespace UraApp.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
