using MediatR;

public record UpdateTaskCommand(int Id) : IRequest<ToDoTask>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Status { get; set; }
    public DateTime DataVencimento { get; set; }
}