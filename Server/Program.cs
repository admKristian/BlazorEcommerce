global using BlazorEcommerce.Shared;
global using Microsoft.EntityFrameworkCore;
global using BlazorEcommerce.Server.Data;

// Create the builder for the web app
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add endpoints for API Explorer and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Create the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Use Swagger and HTTPS
app.UseSwagger();
app.UseHttpsRedirection();

// Add Blazor WebAssembly and static files
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

// Map the default routes
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

// Run the app
app.Run();