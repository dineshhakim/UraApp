 
using System.Collections.Generic;
using UraApp.Models;
using UraApp.Repository.Abstract;
using UraApp.Repository.Infrastructure;
using UraApp.Services.Abstract;


namespace UraApp.Services.Impl
{
    public class RoleTypeService : IRoleTypeService
    {
        private readonly IRoleTypeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public RoleTypeService(IRoleTypeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public RoleType Add(RoleType entity)
        {
            entity = repository.Add(entity);
            unitOfWork.Commit();
            return entity;

        }

        public RoleType Update(RoleType entity)
        {
            entity = repository.Update(entity);
            unitOfWork.Commit();
            return entity;
        }

        public void Delete(RoleType entity)
        {
            repository.Delete(entity);
            unitOfWork.Commit();
        }

        public IEnumerable<RoleType> GetAll()
        {
            return repository.GetAll();
        }

        public RoleType GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
