using FluentAssertions;
using System.Threading.Tasks;
using UnitTestsModule.Domain;
using UnitTestsModule.Repository;
using Xunit;

namespace UnitTestsModule.RepositoryTests
{
    public class StudentRepositoryTests
    {
        private readonly InMemoryDataBaseContext dbContext;
        private readonly StudentRepository repository;

        public StudentRepositoryTests()
        {
            this.dbContext = new InMemoryDataBaseContext();
            this.repository = new StudentRepository(this.dbContext);
        }

        [Fact]
        public async Task InsertOrUpdateAsync_CorrectStudent_ShouldReturnSuccess()
        {
            // Arrange
            var student = new Student("Name");

            // Act
            var result = await this.repository.InsertOrUpdateAsync(student);

            // Assert
            result.Should().Be(1);
        }
    }
}
