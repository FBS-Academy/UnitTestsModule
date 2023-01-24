using System.Threading.Tasks;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Application
{
    public interface IStudentService
    {
        Task<int> InsertAsync(Student student);
    }
}
