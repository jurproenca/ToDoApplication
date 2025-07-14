using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IValidator<CreateTaskCommand>, CreateTaskCommandValidator>();
builder.Services.AddScoped<IRequestHandler<UpdateTaskCommand, ToDoTask>, UpdateTaskCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteTaskCommand, bool>, DeleteTaskCommandHandler>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskCommandValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();