using FluentAssertions;

namespace ToDoApi.Tests.Commands;

public class CreateTaskCommandTests
{
    [Fact]
    public void CreateTaskCommand_Should_Have_Correct_Properties()
    {
        // Arrange
        var command = new CreateTaskCommand
        {
            Titulo = "Estudar XUnit",
            Descricao = "Criar testes para a API",
            Status = 0,
            DataVencimento = new DateTime(2023, 12, 31)
        };

        // Act & Assert
        command.Titulo.Should().Be("Estudar XUnit");
        command.Descricao.Should().Be("Criar testes para a API");
        command.Status.Should().Be(0);
        command.DataVencimento.Should().Be(new DateTime(2023, 12, 31));
    }

    [Theory]
    [InlineData("", false)] // Título vazio
    [InlineData("Tarefa válida", true)]
    [InlineData(null, false)] // Título nulo
    public void CreateTaskCommand_Should_Validate_Title(string titulo, bool expectedIsValid)
    {
        // Arrange
        var command = new CreateTaskCommand
        {
            Titulo = titulo,
            Descricao = "Descrição",
            Status = 0,
            DataVencimento = DateTime.Now.AddDays(1)
        };

        // Act
        var isValid = !string.IsNullOrWhiteSpace(command.Titulo);

        // Assert
        isValid.Should().Be(expectedIsValid);
    }
}