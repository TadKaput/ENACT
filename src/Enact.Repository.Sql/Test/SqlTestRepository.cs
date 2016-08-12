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
    public sealed class SqlTestRepository : CrudRepository<TestModel>, ITestRepository
    {
        public SqlTestRepository(object context) : base(context) { }

        public Task<IEnumerable<TestModel>> GetTestModelsByMyInts(List<string> myStrings)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TestModel>> GetTestModelsByMyInts(List<int> myInts)
        {
            throw new NotImplementedException();
        }
    }
}
