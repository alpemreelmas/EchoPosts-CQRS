using DotnetBlogApi.Application.Common.Interfaces;
using DotnetBlogApi.Domain.Entities;

namespace DotnetBlogApi.Application.Articles.Commands.CreateArticle;

public record CreateArticleCommand : IRequest<int>
{
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Content { get; init; }
    public int? AuthorId { get; init; }
    
    public int? CategoryId { get; init; }
}

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = new Article
        {
            Title = request.Title,
            Content = request.Content,
            Description = request.Description,
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
        };

        _context.Article.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
