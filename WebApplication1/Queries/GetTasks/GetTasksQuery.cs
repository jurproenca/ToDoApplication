using MediatR;

namespace TodoApi.Queries.GetTasks;

public record GetTasksQuery(
    string? Status,      
    DateTime? DataVencimento    
) : IRequest<IEnumerable<ToDoTask>>;