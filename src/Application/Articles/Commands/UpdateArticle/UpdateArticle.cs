using DotnetBlogApi.Application.Common.Interfaces;

namespace DotnetBlogApi.Application.Categories.Commands.UpdateCategory;

public record UpdateArticleCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Content { get; init; }
    public int? AuthorId { get; init; }
}

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Article
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.Content = request.Content;
        entity.AuthorId = request.AuthorId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
