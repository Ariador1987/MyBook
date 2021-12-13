using BookAPI.DAL;
using BookAPI.Domain.Mappings;
using BookAPI.Repository.Contracts;
using BookAPI.Repository.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Cors policy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Books API",
        Version = "v1",
        Description = "A simple API"
    });
    var xFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xPath = Path.Combine(AppContext.BaseDirectory, xFile);
    x.IncludeXmlComments(xPath);
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddAutoMapper(typeof(Maps));
builder.Services.AddControllers();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "My Books API V1");
    x.RoutePrefix = "";
});
app.UseCors("Cors policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
