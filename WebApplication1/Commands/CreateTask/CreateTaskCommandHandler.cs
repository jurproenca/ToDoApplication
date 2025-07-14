using FluentValidation;
using MediatR;
using TodoApi.Data;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int> 
{
    private readonly AppDbContext _context;

    public CreateTaskCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new ToDoTask
        {
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            Status = (int)request.Status,
            DataVencimento = request.DataVencimento
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}