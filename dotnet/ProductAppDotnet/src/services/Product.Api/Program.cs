using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Product.Api.Abstractions;
using Product.Api.Models.Contexts;
using Product.Api.Models.Entities;
using Product.Api.Services;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shared.Extensions;
using Shared.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.Authority = "http://localhost:5001";
    options.Audience = "product_resource";
    options.RequireHttpsMetadata = false;
});


builder.Services.AddDbContext<ProductDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});


var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Product.Api.Models.Entities.Product>("Products");
modelBuilder.EntitySet<Category>("Categories");

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ValidateModelAttribute>();

}).AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();   

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    //app.UseSwaggerUI();

    app.DelayForDevelopment();
}

//app.UseHttpsRedirection();

app.CustomExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
