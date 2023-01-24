using System.Threading.Tasks;
using UnitTestsModule.Application.Repositories;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Application
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Task<int> InsertAsync(Student student) => this.studentRepository.InsertOrUpdateAsync(student);
    }
}
