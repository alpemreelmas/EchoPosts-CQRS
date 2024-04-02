using DotnetBlogApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace DotnetBlogApi.Application.Categories.EventHandlers;

public class CategoryCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<CategoryCreatedEventHandler> _logger;

    public CategoryCreatedEventHandler(ILogger<CategoryCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("DotnetBlogApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
