using Enact.Models;
using Enact.Models.DependencyInjection;
using Enact.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Business
{
    public abstract class CrudManager<TPrimaryObjectType> where TPrimaryObjectType : GenericMetadata
    {
        private CrudRepository<TPrimaryObjectType> _crudRepository;

        public CrudManager(CrudRepository<TPrimaryObjectType> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public void Create(int id, TPrimaryObjectType item)
        {
            _crudRepository.Create(id, item);
        }
        public TPrimaryObjectType Read(int key)
        {
            return _crudRepository.Read(key);
        }

        public void Update(TPrimaryObjectType item)
        {
            _crudRepository.Update(item);
        }

        public void Delete(int key)
        {
            _crudRepository.Delete(key);
        }
        
    }
}
