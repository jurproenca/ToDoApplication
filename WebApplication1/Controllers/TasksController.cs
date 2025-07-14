using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TodoApi.Queries.GetTasks;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string? status,
        [FromQuery] DateTime? dataVencimento)
    {
        var query = new GetTasksQuery(status, dataVencimento);
        var tasks = await _mediator.Send(query);
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _mediator.Send(new GetTaskByIdQuery { Id = id });

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        var validator = new CreateTaskCommandValidator();
        var validationResult = validator.Validate(command);

        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Error = "Validação falhou",
                Details = validationResult.Errors.Select(e => e.ErrorMessage)
            });
        }

        try
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }
        catch (Exception ex)
        {
            if (ex.InnerException is SqlException sqlEx &&
                (sqlEx.Number == 2628 || sqlEx.Number == 8152))
            {
                return BadRequest("Status inválido. Use apenas: 0-Pendente, 1-Em Andamento, 2-Concluído");
            }

            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskCommand command)
    {
        var fullCommand = command with { Id = id };

        var validator = new UpdateTaskCommandValidator();
        var validationResult = await validator.ValidateAsync(fullCommand);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await _mediator.Send(fullCommand);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteTaskCommand { Id = id };

        var validator = new DeleteTaskCommandValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound("Tarefa não encontrada");
        }

        return NoContent();
    }

}