using Enact.Models.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Repository.Es.Test
{
    public sealed class ElasticSearchTestRepository : CrudRepository<TestModel>
    {
        public ElasticSearchTestRepository() : base()
        {
            _table = new List<TestModel>()  //#Fake
            {
                TestModel.Fake(1),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
            };
        }

    }
}
