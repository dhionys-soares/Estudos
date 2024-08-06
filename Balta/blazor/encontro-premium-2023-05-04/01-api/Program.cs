var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
});

var app = builder.Build();

var categories = new List<Category>
{
    new Category(1, "Informática", "Produtos de Informática"),
    new Category(2, "Limpeza", "Produtos de Limpeza"),
    new Category(3, "Cozinha", "Produtos para cozinha"),
    new Category(4, "Decoraçãop", "Produtos de decoração")
};

app.MapGet("/v1/categories", () => categories);
app.MapGet("/v1/categories/{id}", (int id) => categories.FirstOrDefault(x => x.Id == id));
app.MapPost("/v1/categories", (Category model) =>
{
    model.Id = categories.Count + 1;
    categories.Add(model);
    return Results.Created($"v1/categories/{model.Id}", model);
});
app.MapPut("/v1/categories/{id}", (int id, Category model) =>
{
    var category = categories.FirstOrDefault(x => x.Id == id);
    if (category == null)
        return Results.NotFound();

    category.Title = model.Title;
    category.Description = model.Description;

    return Results.Ok(category);
});
app.MapDelete("/v1/categories/{id}", (int id) =>
{
    var category = categories.FirstOrDefault(x => x.Id == id);
    if (category == null)
        return Results.NotFound();

    categories.Remove(category);

    return Results.Ok(category);
});

app.UseCors(MyAllowSpecificOrigins);
app.Run();

public class Category
{
    public Category(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}