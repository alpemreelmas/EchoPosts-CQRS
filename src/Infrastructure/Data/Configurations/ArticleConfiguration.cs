using DotnetBlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetBlogApi.Infrastructure.Data.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(t => t.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Content)
            .IsRequired();
        
        builder.Property(t => t.AuthorId)
            .IsRequired();
    }
}
