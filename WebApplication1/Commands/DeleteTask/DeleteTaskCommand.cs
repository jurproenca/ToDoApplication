using MediatR;

public record DeleteTaskCommand : IRequest<bool>
{
    public int Id { get; set; }
}