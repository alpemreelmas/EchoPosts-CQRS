using DotnetBlogApi.Domain.Entities;

namespace DotnetBlogApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Category> Category { get; }
    DbSet<Article> Article { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
