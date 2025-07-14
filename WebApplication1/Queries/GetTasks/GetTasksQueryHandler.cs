using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<ToDoTask>>
    {
        private readonly AppDbContext _context;

        public GetTasksQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTask>> Handle(
            GetTasksQuery query,
            CancellationToken cancellationToken)
        {
            var queryable = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(query.Status))
                queryable = queryable.Where(t => t.Status.ToString() == query.Status);

            if (query.DataVencimento.HasValue)
                queryable = queryable.Where(t => t.DataVencimento.Date == query.DataVencimento.Value.Date);

            return await queryable.ToListAsync(cancellationToken);
        }
    }
}