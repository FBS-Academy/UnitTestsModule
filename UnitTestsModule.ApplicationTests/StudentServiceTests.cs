using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using UnitTestsModule.Application;
using UnitTestsModule.Application.Repositories;
using UnitTestsModule.Domain;
using Xunit;

namespace UnitTestsModule.ApplicationTests
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> studentRepository;
        private readonly StudentService studentService;

        public StudentServiceTests()
        {
            this.studentRepository = new Mock<IStudentRepository>();
            this.studentService = new StudentService(this.studentRepository.Object);
        }

        [Fact]
        public async Task InsertAsync_CorrectStudent_ShouldReturnSuccess()
        {
            // Arrange
            this.studentRepository.Setup(repository => repository.InsertOrUpdateAsync(It.IsAny<Student>()))
                .ReturnsAsync(1);

            var student = new Student("Name");

            // Act
            var result = await this.studentService.InsertAsync(student);

            // Assert
            result.Should().Be(1);
        }
    }
}
