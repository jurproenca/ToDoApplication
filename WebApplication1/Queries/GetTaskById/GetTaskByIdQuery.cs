using MediatR;

public class GetTaskByIdQuery : IRequest<ToDoTask>
{
    public int Id { get; set; }
}