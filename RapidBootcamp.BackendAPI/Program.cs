using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.DAL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register entity framework
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//DI
builder.Services.AddScoped<ICategory, CategoryEF>();
builder.Services.AddScoped<IProduct, ProductEF>();
builder.Services.AddScoped<IOrderHeaders, OrderHeaderEF>();
builder.Services.AddScoped<IOrderDetail, OrderDetailsDAL>();
builder.Services.AddScoped<IWallet, WalletsDAL>();

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