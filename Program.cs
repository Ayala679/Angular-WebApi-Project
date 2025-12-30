using Chinese_Auction.Data;
using Chinese_Auction.Mappings;
using Chinese_Auction.Repository;
using Chinese_Auction.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChineseAuctionDbContext>(options =>
        options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;DataBase=Chinese_Auction;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));

//scoped for repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();


//scoped for services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IGiftService, GiftService>();

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
