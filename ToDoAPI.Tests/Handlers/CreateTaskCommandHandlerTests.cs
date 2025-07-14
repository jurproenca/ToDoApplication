using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Data;
using Xunit;

namespace ToDoApi.UnitTests.Handlers
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsTaskId()
        {
            // Arrange
            var mockSet = new Mock<DbSet<ToDoTask>>();
            var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            var testTask = new ToDoTask { Id = 1 };

            mockSet.Setup(x => x.Add(It.IsAny<ToDoTask>()))
                   .Callback<ToDoTask>(t => t.Id = testTask.Id);

            mockContext.Setup(x => x.Tasks).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                      .ReturnsAsync(1);

            var handler = new CreateTaskCommandHandler(mockContext.Object);
            var command = new CreateTaskCommand
            {
                Titulo = "Teste",
                Descricao = "Descrição",
                Status = 0,
                DataVencimento = DateTime.Now.AddDays(1)
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(1, result); // Agora esperamos o ID específico
            mockSet.Verify(x => x.Add(It.IsAny<ToDoTask>()), Times.Once);
        }
    }
}