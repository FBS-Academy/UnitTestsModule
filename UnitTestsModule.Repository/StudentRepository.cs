using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnitTestsModule.Application.Repositories;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <returns>A task that represents the asynchronous insert or update operation. The task result contains the number of state entries written to the database.</returns>
        public Task<int> InsertOrUpdateAsync(Student entity)
        {
            this.InsertOrUpdate(entity);

            return this.SaveChanges();
        }
    }
}
