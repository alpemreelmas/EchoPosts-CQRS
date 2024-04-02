
namespace DotnetBlogApi.Domain.Entities;

public class Article : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public ApplicationUser? Author { get; set; }
}
