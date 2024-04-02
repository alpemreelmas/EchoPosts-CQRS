using DotnetBlogApi.Application.Common.Interfaces;
using DotnetBlogApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DotnetBlogApi.Application.Articles.Commands.CreateArticle;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public CreateArticleCommandValidator(IApplicationDbContext context,UserManager<ApplicationUser> userManager)
    {
     
        _context = context;
        _userManager = userManager;
        
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Content)
            .NotEmpty();
        
        RuleFor(v => v.AuthorId)
            .NotEmpty()
            .MustAsync(ShouldExistUser)
                .WithMessage("'{PropertyName}' must be exist.")
                .WithErrorCode("ExistUser");
        
        RuleFor(v => v.CategoryId)
            .NotEmpty()
            .MustAsync(ShouldExistCategory)
                .WithMessage("'{PropertyName}' must be exist.")
                .WithErrorCode("ExistCategory");
            
    }
    
    public async Task<bool> ShouldExistCategory(int? id, CancellationToken cancellationToken)
    {
        return await _context.Category
            .AllAsync(l => l.Id == Convert.ToInt32(id), cancellationToken);
    }
    
    public async Task<bool> ShouldExistUser(int? id, CancellationToken cancellationToken)
    {
        return await _userManager.FindByIdAsync(Convert.ToString(id)!) != null;    
    }
}
