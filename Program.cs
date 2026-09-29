using Microsoft.EntityFrameworkCore;
using InventoryApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // controller service

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=inventory.db"));

var app = builder.Build();

app.MapControllers();

app.Run(); // start

