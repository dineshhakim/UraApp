using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;
using UraApp.Services.Abstract;

namespace UraApp.Services.Impl
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public PortfolioService(IPortfolioRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Portfolio Add(Portfolio entity)
        {
            entity = repository.Add(entity);
            unitOfWork.Commit();
            return entity;

        }

        public Portfolio Update(Portfolio entity)
        {
            entity = repository.Update(entity);
            unitOfWork.Commit();
            return entity;
        }

        public void Delete(Portfolio entity)
        {
            repository.Delete(entity);
            unitOfWork.Commit();
        }

        public IEnumerable<Portfolio> GetAll()
        {
            return repository.GetAll();
        }

        public Portfolio GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
