using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Models.RepositoryInjection
{
    public interface IEsTestRepository
    {
        Task<IEnumerable<TestModel.TestModel>> GetTestModelsByMyInts(List<int> myInts);
        
        Task<IEnumerable<TestModel.TestModel>> GetTestModelsByMyInts(List<string> myStrings);

        bool MapType();
    }

    public interface ISqlTestRepository
    {
        Task<object> Foo();
    }
}
