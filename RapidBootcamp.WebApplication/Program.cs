using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.DAL;

var builder = WebApplication.CreateBuilder(args);

//register dbcontext untuk EF
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// menambahkan modul mvc
builder.Services.AddControllersWithViews();

// menambahkan DI
//builder.Services.AddScoped<ICategory, CategoriesDAL>();

builder.Services.AddScoped<ICategory, CategoriesEF>();

builder.Services.AddScoped<ICustomer, CustomersDAL>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();