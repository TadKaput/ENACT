using Enact.Models.DependencyInjection;
using Enact.Models.TestModel;
using System.Collections.Generic;
using System.Linq;

namespace Enact.Repository.Sql.Test
{
    [SingletonDependency]
    public sealed class SqlTestRepository : CrudRepository<TestModel>
    {
        public SqlTestRepository() : base()
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
