using DotnetBlogApi.Application.Common.Interfaces;
using DotnetBlogApi.Domain.Common;
using DotnetBlogApi.Domain.Entities;

namespace DotnetBlogApi.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand : IRequest<ResultObject<Category>>
{
    public int Id { get; init; }

    public string? Name { get; init; }

}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,ResultObject<Category>>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultObject<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Category
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Category>.Success(entity);
    }
}
