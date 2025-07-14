using FluentValidation;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID da tarefa é obrigatório.")
            .GreaterThan(0).WithMessage("O ID da tarefa deve ser maior que zero.");

        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
            .MaximumLength(100).WithMessage("O título não pode ter mais de 100 caracteres.");

        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");

        RuleFor(x => x.Status)
            .InclusiveBetween(0, 2).WithMessage("O status deve ser 0 (Pendente), 1 (Em Andamento) ou 2 (Concluído).");

        RuleFor(x => x.DataVencimento)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("A data de vencimento não pode ser no passado.");
    }
}