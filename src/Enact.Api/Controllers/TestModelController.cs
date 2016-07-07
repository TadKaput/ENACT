using Enact.Business.Test;
using Enact.Models.DependencyInjection;
using Enact.Models.TestModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Enact.Api.Controllers
{
    [ScopedDependency]
    [Route("api/[controller]")]
    public class TestModelController : CrudController<TestModel>
    {
        public TestModelController(TestModelManager manager) : base(manager)
        {
            
        }
        
        [HttpGet("GetAllStuff")]
        public List<TestModel> GetAllStuff()
        {
            return TestModel.FakeList();
        }
    }
}
