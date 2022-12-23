using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.Extensions.Primitives;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        if (string.IsNullOrEmpty(categoryRequest.Name))
            return Results.BadRequest("Name is Required");
        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedBy = "Teste",
            CreatedOn = DateTime.Now,
            UpdatedBy = "Teste",
            UpdatedOn = DateTime.Now
        };
        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }

}
