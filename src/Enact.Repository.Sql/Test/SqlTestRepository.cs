using Enact.Models.DependencyInjection;
using Enact.Models.RepositoryInjection;
using Enact.Models.TestModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Enact.Repository.Sql.Test
{
    [SingletonDependency]
    public sealed class SqlTestRepository : SqlCrudRepository<TestModel>, ISqlTestRepository
    {
        public SqlTestRepository(object context) : base(context) { }

        public Task<object> Foo()
        {
            throw new NotImplementedException();
        }
    }
}
