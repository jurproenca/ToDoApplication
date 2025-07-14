using FluentValidation;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório")
            .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres");

        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres");

        RuleFor(x => x.Status)
            .Must(BeValidStatusInt).WithMessage("Status deve ser 0 (Pendente), 1 (Em Andamento) ou 2 (Concluído)");

        RuleFor(x => x.DataVencimento)
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("A data de vencimento não pode ser no passado");

    }
    
    private bool BeValidStatusInt(int status)
    {
        return status >= 0 && status <= 2;
    }
}