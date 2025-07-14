using MediatR;

public record CreateTaskCommand : IRequest<int>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Status { get; set; }
    public DateTime DataVencimento { get; set; }
}