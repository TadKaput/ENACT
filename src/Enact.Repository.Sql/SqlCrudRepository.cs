using Enact.Models;
using Enact.Models.RepositoryInjection;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Enact.Repository.Sql
{
    /// <summary>
    /// EF repository
    /// </summary>
    public class SqlCrudRepository<TPrimaryObjectType> : ICrudRepository<TPrimaryObjectType> where TPrimaryObjectType : GenericMetadata
    {
        //private DbContext _context;

        public SqlCrudRepository(object context)
        {
            throw new NotImplementedException();
        }

        public void Create(TPrimaryObjectType item)
        {
            throw new NotImplementedException();
        }
        public TPrimaryObjectType Read(string id, bool includeVersion = true)
        {
            throw new NotImplementedException();
        }

        public long Update(TPrimaryObjectType item, bool includeVersion = true)
        {
            throw new NotImplementedException();
        }
        
        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }
        
    }
}
