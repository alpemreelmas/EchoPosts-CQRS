using DotnetBlogApi.Application.Common.Interfaces;
using DotnetBlogApi.Domain.Events;

namespace DotnetBlogApi.Application.Articles.Commands.DeleteArticle;

public record DeleteArticleCommand(int Id) : IRequest;

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Article
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Article.Remove(entity);

        //entity.AddDomainEvent(new CategoryDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
