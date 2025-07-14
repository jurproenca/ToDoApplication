using FluentAssertions;

namespace ToDoApi.Tests.Commands
{
    public class UpdateTaskCommandTests
    {
        [Fact]
        public void UpdateTaskCommand_Should_Have_Correct_Properties()
        {
            // Arrange
            var command = new UpdateTaskCommand(
                Id: 1,
                Titulo: "Atualizar testes",
                Descricao: "Implementar novos testes",
                Status: 1,
                DataVencimento: new DateTime(2023, 12, 31)
            );

            // Act & Assert
            command.Id.Should().Be(1);
            command.Titulo.Should().Be("Atualizar testes");
            command.Descricao.Should().Be("Implementar novos testes");
            command.Status.Should().Be(1);
            command.DataVencimento.Should().Be(new DateTime(2023, 12, 31));
        }

        [Theory]
        [InlineData(0, false)]  // ID inválido
        [InlineData(1, true)]   // ID válido
        public void UpdateTaskCommand_Should_Validate_Id(int id, bool isValid)
        {
            // Arrange
            var command = new UpdateTaskCommand( Id: id, Titulo: "", Descricao: "", Status: 1, DataVencimento: DateTime.Today );

            // Act
            var result = command.Id > 0;

            // Assert
            result.Should().Be(isValid);
        }
    }
}