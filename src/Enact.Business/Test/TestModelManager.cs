using Enact.Models.DependencyInjection;
using Enact.Models.RepositoryInjection;
using Enact.Models.TestModel;
using Enact.Repository.Sql.Test;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enact.Business.Test
{
    [SingletonDependency]
    public class TestModelManager : CrudManager<TestModel>
    {
        public ITestRepository _testRepository;

        public TestModelManager(ITestRepository testRepository) : base(testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<IEnumerable<TestModel>> GetMyData(List<int> myInts)
        {
            var testModels = await _testRepository.GetTestModelsByMyInts(myInts);
            return testModels;
        }
    }
}
