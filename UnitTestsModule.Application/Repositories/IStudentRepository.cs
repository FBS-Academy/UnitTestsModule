using System.Threading.Tasks;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Application.Repositories
{
    public interface IStudentRepository
    {
        /// <returns>A task that represents the asynchronous insert or update operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> InsertOrUpdateAsync(Student entity);
    }
}
