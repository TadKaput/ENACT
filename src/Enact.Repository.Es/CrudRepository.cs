using Enact.Models;
using System.Collections.Generic;
using System.Linq;

namespace Enact.Repository.Es
{
    /// <summary>
    /// Faked repository (for now, until EF is implemented)
    /// </summary>
    public abstract class CrudRepository<TPrimaryObjectType> where TPrimaryObjectType : GenericMetadata
    {
        internal IEnumerable<TPrimaryObjectType> _table;

        public CrudRepository()
        {
            _table = new List<TPrimaryObjectType>(); //fake for now
        }

        public void Create(int id, TPrimaryObjectType item)
        {
            _table.Append(item);
            //save changes
        }

        public TPrimaryObjectType Read(int key)
        {
            return _table.FirstOrDefault(a => a.Id == key);
        }

        public void Update(TPrimaryObjectType item)
        {
            //_table.Remove(key);
            //_table.Append(item);
            //save changes
        }

        public void Delete(int key)
        {
            //_table.Remove(key);
            //save changes
        }
    }
}
