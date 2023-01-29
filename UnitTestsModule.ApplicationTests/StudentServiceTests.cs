using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestsModule.Application;
using UnitTestsModule.Application.Repositories;
using UnitTestsModule.Domain;
using UnitTestsModule.Domain.Exceptions;
using UnitTestsModule.TestsInfrastruture;
using Xunit;

namespace UnitTestsModule.ApplicationTests
{
    public class StudentServiceTests
    {
        [Theory, AutoMoqData]
        public async Task InsertAsync_CorrectStudent_ShouldReturnSuccess(
            [Frozen] Mock<IStudentRepository> studentRepository,
            StudentService studentService,
            Student student)
        {
            // Arrange
            studentRepository.Setup(repository => repository.InsertOrUpdateAsync(It.IsAny<Student>()))
                .ReturnsAsync(1);

            // Act
            var result = await studentService.InsertAsync(student);

            // Assert
            result.Should().Be(1);
        }

        [Theory, AutoMoqData]
        public async Task InsertAsync_StudentWithPropertyNameFilled_RepositoryShouldReceiveTheStudentCorrectlyFilled(
            [Frozen] Mock<IStudentRepository> studentRepository,
            StudentService studentService,
            Student student)
        {
            // Arrange
            studentRepository.Setup(repository => repository.InsertOrUpdateAsync(It.IsAny<Student>()))
                .Verifiable();

            // Act
            var result = await studentService.InsertAsync(student);

            // Assert
            studentRepository.Verify(repository => repository.InsertOrUpdateAsync(It.Is<Student>(s => s.Name == student.Name)), Times.Once);
        }

        [Theory, MemberAutoMoqData(nameof(StudentTestData))]
        public async Task InsertAsync_StudentInvalidName_ShouldThrowException(
            string name, 
            string expectedMessage,
            StudentService studentService,
            Student student)
        {
            // Arrange
            student.Name = name;

            // Act
            Func<Task> action = async () => await studentService.InsertAsync(student);

            // Assert
            var exception = action.Should().ThrowAsync<DomainException>()
                .WithMessage("Existem erros no estudante.").GetAwaiter().GetResult().And;

            exception.ErrorMessages.Should().HaveCount(1);
            exception.ErrorMessages.Should().Contain(e => e.Property == nameof(student.Name) && e.Message == expectedMessage);
        }

        public static IEnumerable<object[]> StudentTestData() => new List<object[]>()
        {
            new object[] { string.Empty, $"A propriedade {nameof(Student.Name)} não pode estar vazia." },
            new object[] { null, $"A propriedade {nameof(Student.Name)} não pode estar vazia." }
        };
    }
}
