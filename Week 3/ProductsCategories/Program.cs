using Microsoft.EntityFrameworkCore;
// ### CHANGE THIS TO PROJECT NAME ###
using ProductsCategories.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();  
builder.Services.AddSession();
//              ######## CHANGE TO CONTEXT NAME #########
builder.Services.AddDbContext<MyContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();