using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DataBase
var ConnetionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(ConnetionString));
#endregion


builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IItemRepo, ItemRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
