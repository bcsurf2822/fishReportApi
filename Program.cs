using FishReportApi.Data;
using FishReportApi.Repositories;
using FishReportApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//DB CONTEXT
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FishDBContext>(options =>
    options.UseSqlite(connectionString));


//REPOSITORIES
builder.Services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
builder.Services.AddScoped<IFishRepository, FishRepository>();
builder.Services.AddScoped<IFishMarketRepository, FishMarketRepository>();


//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocal5173", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
    });
    options.AddPolicy("AllowAll", policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});
    options.AddPolicy("AllowFisheriesService", policy =>
{
    policy.WithOrigins("https://", "https://")
          .AllowAnyMethod()
          .AllowAnyHeader();
});
    options.AddPolicy("AllowMarkets", policy =>
    {
        policy.WithOrigins("https://myfrontend.com")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
    options.AddPolicy("AllowPublic", policy =>
{
    policy.WithOrigins("https://", "https://")
          .AllowAnyMethod()
          .AllowAnyHeader();
});
});

// Services
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(Program));


//BUILDS APP
var app = builder.Build();

//CORS
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
}
else
{
    app.UseCors("AllowFrontendOnly");
}


// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();