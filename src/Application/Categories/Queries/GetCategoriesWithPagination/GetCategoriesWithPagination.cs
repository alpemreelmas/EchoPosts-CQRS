using DotnetBlogApi.Application.Common.Interfaces;
using DotnetBlogApi.Application.Common.Mappings;
using DotnetBlogApi.Application.Common.Models;
using DotnetBlogApi.Domain.Common;
using DotnetBlogApi.Domain.Entities;

namespace DotnetBlogApi.Application.Categories.Queries.GetCategoriesWithPagination;

public record GetCategoriesWithPaginationQuery : IRequest<ResultObject<PaginatedList<Category>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCategoriesWithPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery, ResultObject<PaginatedList<Category>>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResultObject<PaginatedList<Category>>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Category
            .OrderBy(x => x.Name)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return Result<PaginatedList<Category>>.Success(entities);
    }
}
