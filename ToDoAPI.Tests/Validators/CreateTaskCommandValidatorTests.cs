using FluentAssertions;

namespace ToDoApi.UnitTests.Validators;

public class CreateTaskCommandValidatorTests
{
    private readonly CreateTaskCommandValidator _validator = new();

    [Fact]
    public void Validate_WhenTitleIsEmpty_ShouldBeInvalid()
    {
        // Arrange
        var command = new CreateTaskCommand { Titulo = "", DataVencimento = DateTime.Today.AddDays(1) };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();

        result.Errors.Select(e => e.ErrorMessage)
          .Should().Contain(m => m.Contains("título é obrigatório"));
    }

    [Fact]
    public void Validate_WhenDateInvalid_ShouldBeInvalid()
    {
        // Arrange
        var command = new CreateTaskCommand { Titulo = "Teste", DataVencimento = DateTime.Today.AddDays(-1) };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();

        result.Errors.Select(e => e.ErrorMessage)
          .Should().Contain(m => m.Contains("data de vencimento não pode ser no passado"));
    }
}