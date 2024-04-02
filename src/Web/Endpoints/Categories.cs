using DotnetBlogApi.Application.Categories.Commands.CreateCategory;
using DotnetBlogApi.Application.Categories.Commands.DeleteCategory;
using DotnetBlogApi.Application.Categories.Commands.UpdateCategory;
using DotnetBlogApi.Application.Categories.Queries.GetCategoriesWithPagination;
using DotnetBlogApi.Application.Common.Models;
using DotnetBlogApi.Domain.Common;
using DotnetBlogApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBlogApi.Web.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetTodoLists)
            .MapPost(CreateCategory)
            .MapDelete(DeleteCategory, "{id}")
            .MapPut(UpdateCategory, "{id}");

        /*.MapPost(CreateTodoList)
        .MapPut(UpdateTodoList, "{id}")
        .MapDelete(DeleteTodoList, "{id}");*/
    }
    
    public Task<int> CreateCategory(ISender sender, [FromBody] CreateCategoryCommand command)
    {
        return sender.Send(command);
    }
    
    public Task<ResultObject> DeleteCategory(ISender sender, [FromBody] DeleteCategoryCommand command)
    {
        return sender.Send(command);
    }
    
    public Task<ResultObject<Category>> UpdateCategory(ISender sender, [FromBody] UpdateCategoryCommand command)
    {
        return sender.Send(command);
    }
    
    public Task<ResultObject<PaginatedList<Category>>> GetTodoLists(ISender sender)
    {
        return  sender.Send(new GetCategoriesWithPaginationQuery());
    }
}
