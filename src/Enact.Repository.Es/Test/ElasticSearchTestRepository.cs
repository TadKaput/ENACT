using Enact.Models.DependencyInjection;
using Enact.Models.RepositoryInjection;
using Enact.Models.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Repository.Es.Test
{
    
    public sealed class ElasticSearchTestRepository : EsCrudRepository<TestModel>, IEsTestRepository
    {
        public ElasticSearchTestRepository(RepositoryClient client) : base(client) { }
        
        public async Task<IEnumerable<TestModel>> GetTestModelsByMyInts(List<int> myInts)
        {
            var testModels = await GetAllByQueryAsync(q => q.Terms(t => t.Field(f => f.MyInt).Terms(myInts)));
            return testModels;
        }

        public async Task<IEnumerable<TestModel>> GetTestModelsByMyInts(List<string> myStrings)
        {
            var testModels = await GetAllByQueryAsync(q => q.Terms(t => t.Field(f => f.MyString).Terms(myStrings)));
            return testModels;
        }
        
    }
}
