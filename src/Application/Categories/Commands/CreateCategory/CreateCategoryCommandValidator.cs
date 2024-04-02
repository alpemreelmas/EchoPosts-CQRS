using DotnetBlogApi.Application.Common.Interfaces;

namespace DotnetBlogApi.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty()
            .MustAsync(ShouldBeUnique)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("ExistCategory");
    }
    
    public async Task<bool> ShouldBeUnique(string name, CancellationToken cancellationToken)
    {
        return await _context.Category
            .AllAsync(c => c.Name != name,cancellationToken);
    }
}
