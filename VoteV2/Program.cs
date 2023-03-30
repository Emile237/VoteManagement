using Microsoft.EntityFrameworkCore;
using VoteV2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("DEFAULT_POLICY", policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddDbContext<VoteContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection")));
//builder.Services.AddMvc();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("DEFAULT_POLICY");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
