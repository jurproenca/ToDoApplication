using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, ToDoTask>
{
    private readonly AppDbContext _context;

    public GetTaskByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ToDoTask> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
    }
}