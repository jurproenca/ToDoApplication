using FluentValidation;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID da tarefa é obrigatório.")
            .GreaterThan(0).WithMessage("O ID da tarefa deve ser maior que zero.");
    }
}