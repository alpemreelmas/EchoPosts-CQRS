using DotnetBlogApi.Application.Common.Interfaces;

namespace DotnetBlogApi.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }

}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Category
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
