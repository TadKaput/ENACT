using Enact.Business;
using Enact.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Enact.Api.Controllers
{
    public abstract class CrudController<TPrimaryObjectType> : Controller where TPrimaryObjectType : GenericMetadata
    {
        private CrudManager<TPrimaryObjectType> _crudManager;
        public CrudController(CrudManager<TPrimaryObjectType> crudManager)
        {
            _crudManager = crudManager;
        }

        [HttpGet("{id}")]
        public TPrimaryObjectType Get(int id)
        {
            return _crudManager.Read(id);
        }

        [HttpPost]
        public void Post([FromBody]TPrimaryObjectType value)
        {
            _crudManager.Update(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TPrimaryObjectType value)
        {
            _crudManager.Create(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _crudManager.Delete(id);
        }
    }
}
