using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using UnitTestsModule.Application;
using UnitTestsModule.Application.Repositories;
using UnitTestsModule.Domain;
using Xunit;
using AutoFixture;

namespace UnitTestsModule.ApplicationTests
{
    public class StudentServiceTests : BaseTests
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

            var student = this.fixture.Create<Student>();

            // Act
            var result = await this.studentService.InsertAsync(student);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public async Task InsertAsync_StudentWithPropertyNameFilled_RepositoryShouldReceiveTheStudentCorrectlyFilled()
        {
            // Arrange
            this.studentRepository.Setup(repository => repository.InsertOrUpdateAsync(It.IsAny<Student>()))
                .Verifiable();

            var student = this.fixture.Create<Student>();

            // Act
            var result = await this.studentService.InsertAsync(student);

            // Assert
            this.studentRepository.Verify(repository => repository.InsertOrUpdateAsync(It.Is<Student>(s => s.Name == student.Name)), Times.Once);
        }
    }
}
