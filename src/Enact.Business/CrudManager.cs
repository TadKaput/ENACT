using Enact.Business.Helpers;
using Enact.Models;
using Enact.Models.RepositoryInjection;
using Enact.Repository.Es;
using Enact.Repository.Sql;
using System;

namespace Enact.Business
{
    public class CrudManager<TPrimaryObjectType> where TPrimaryObjectType : GenericMetadata
    {
        private ICrudRepository<TPrimaryObjectType> _crudRepository;

        public CrudManager(EsCrudRepository<TPrimaryObjectType> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public string Create(TPrimaryObjectType item)
        {
            if (string.IsNullOrEmpty(item.Id))
                item.Id = DataHelper.UniqueId();
            _crudRepository.Create(item);
            return item.Id;
        }
        public TPrimaryObjectType Read(string id)
        {
            return _crudRepository.Read(id);
        }

        public long Update(TPrimaryObjectType item)
        {
            return _crudRepository.Update(item);
        }

        public bool Delete(string id)
        {
            return _crudRepository.Delete(id);
        }
        
    }
}
