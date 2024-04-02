using DotnetBlogApi.Application.Categories.Commands.CreateCategory;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBlogApi.Web.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateCategory);
        
        /*.MapPost(CreateTodoList)
        .MapPut(UpdateTodoList, "{id}")
        .MapDelete(DeleteTodoList, "{id}");*/
    }
    
    public Task<int> CreateCategory(ISender sender, [FromBody] CreateCategoryCommand command)
    {
        return sender.Send(command);
    }
}
