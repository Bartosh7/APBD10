using APBD10;
using APBD10.Contexts;
using APBD10.PostModels;
using APBD10.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/accounts/{id:int}", async (int id, IAccountService service) =>
{
    try
    {
        return Results.Ok(await service.GetAccountByIdAssync(id));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});


app.MapPost("api/products", async (PostProductModel productModel, IProductService service) =>
{
    try
    {
        await service.PostProduct(productModel);
        return Results.Created();
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});

app.Run();

