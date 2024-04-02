using DotnetBlogApi.Application.Common.Interfaces;
using DotnetBlogApi.Domain.Events;

namespace DotnetBlogApi.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Category
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Category.Remove(entity);

        //entity.AddDomainEvent(new CategoryDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
