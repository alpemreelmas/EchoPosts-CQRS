namespace DotnetBlogApi.Application.Categories.Commands.UpdateCategory;

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Content)
            .NotEmpty();
        
        RuleFor(v => v.AuthorId)
            .NotEmpty();
    }
}
