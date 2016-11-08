using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;
using UraApp.Services.Abstract;
 
using System.Collections.Generic;
 

namespace UraApp.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(ICompanyRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Company Add(Company entity)
        {
            entity = repository.Add(entity);
            unitOfWork.Commit();
            return entity;

        }

        public Company Update(Company entity)
        {
            entity = repository.Update(entity);
            unitOfWork.Commit();
            return entity;
        }

        public void Delete(Company entity)
        {
            repository.Delete(entity);
            unitOfWork.Commit();
        }

        public IEnumerable<Company> GetAll()
        {
            return repository.GetAll();
        }

        public Company GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
