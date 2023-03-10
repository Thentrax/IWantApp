using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action([FromRoute]Guid Id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(Categories=> Categories.Id == Id).FirstOrDefault();
        context.Categories.Remove(category);
        context.SaveChanges();
        return Results.Ok();
    }

}
