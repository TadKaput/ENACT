using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Models.RepositoryInjection
{
    public interface ITestRepository : ICrudRepository<TestModel.TestModel>
    {
        Task<IEnumerable<TestModel.TestModel>> GetTestModelsByMyInts(List<int> myInts);
        
        Task<IEnumerable<TestModel.TestModel>> GetTestModelsByMyInts(List<string> myStrings);
    }
}
