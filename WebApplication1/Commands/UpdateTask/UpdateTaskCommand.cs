using MediatR;

public record UpdateTaskCommand(
    int Id,
    string Titulo,
    string Descricao,
    int Status,
    DateTime DataVencimento
) : IRequest<ToDoTask>;