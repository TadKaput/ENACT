using Enact.Models.DependencyInjection;
using Enact.Models.TestModel;
using Enact.Repository.Sql.Test;

namespace Enact.Business.Test
{
    [SingletonDependency]
    public class TestModelManager : CrudManager<TestModel>
    {
        public SqlTestRepository _testRepository;

        public TestModelManager(SqlTestRepository testRepository) : base(testRepository)
        {
            _testRepository = testRepository;
        }

        public TestModel GetDataProcessedAndVerified()
        {
            return _testRepository.Read(0);
        }
    }
}
