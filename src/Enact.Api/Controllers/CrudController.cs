using Enact.Business;
using Enact.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Get(string id)
        {
            return Ok(_crudManager.Read(id));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]TPrimaryObjectType item)
        {
            return Created("", _crudManager.Create(item));
        }

        [HttpPut]
        public IActionResult Put([FromBody]TPrimaryObjectType value)
        {
            return Ok(_crudManager.Update(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _crudManager.Delete(id);
            return new NoContentResult();
        }

    }
}
