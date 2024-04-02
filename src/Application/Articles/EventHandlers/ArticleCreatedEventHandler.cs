using DotnetBlogApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace DotnetBlogApi.Application.Categories.EventHandlers;

public class ArticleCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<ArticleCreatedEventHandler> _logger;

    public ArticleCreatedEventHandler(ILogger<ArticleCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("DotnetBlogApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
