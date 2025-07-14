using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, ToDoTask>
{
    private readonly AppDbContext _context;

    public UpdateTaskCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ToDoTask> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new KeyNotFoundException($"Tarefa com ID {request.Id} não encontrada.");
        }

        task.Titulo = request.Titulo;
        task.Descricao = request.Descricao;
        task.Status = request.Status;
        task.DataVencimento = request.DataVencimento;

        await _context.SaveChangesAsync(cancellationToken);

        return task;
    }
}