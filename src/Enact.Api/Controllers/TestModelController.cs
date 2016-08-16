using Enact.Business.Test;
using Enact.Models.DependencyInjection;
using Enact.Models.TestModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Enact.Api.Controllers
{
    [ScopedDependency]
    [Route("api/[controller]")]
    public class TestModelController : CrudController<TestModel>
    {
        private TestModelManager _manager;

        public TestModelController(TestModelManager manager) : base(manager)
        {
            _manager = manager;
        }
        
        [HttpGet("GetMyData")]
        public IActionResult GetMyData([FromQuery]List<int> myInts)
        {
            return Ok(_manager.GetMyData(myInts));
        }

        [HttpPost]
        [Route("MapType")]
        public IActionResult MapType()
        {
            if (_manager.MapType())
                return Created("", "Success!");
            else
                return StatusCode(StatusCodes.Status418ImATeapot);
        }
    }
}
