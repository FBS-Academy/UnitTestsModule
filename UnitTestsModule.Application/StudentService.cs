using System.Threading.Tasks;
using UnitTestsModule.Application.Repositories;
using UnitTestsModule.Domain;
using UnitTestsModule.Domain.Exceptions;

namespace UnitTestsModule.Application
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Task<int> InsertAsync(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
                throw new DomainException("Existem erros no estudante.", new ErrorMessage(nameof(Student.Name), $"A propriedade {nameof(Student.Name)} não pode estar vazia."));

            return this.studentRepository.InsertOrUpdateAsync(student);
        }
    }
}
