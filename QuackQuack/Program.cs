using Data;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using QuackQuack.Mappings;
using QuackQuack.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<PorfolioDbContext>(config =>
{
    config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    config.UseNpgsql(builder.Configuration.GetConnectionString("Porfolio"), dbOptions =>
    {
        dbOptions.CommandTimeout(30);
        dbOptions.EnableRetryOnFailure();
        dbOptions.MigrationsAssembly("Data");
    });
});

builder.Services.AddSingleton<IMapping<BlogPlatform, PlatformResponse>, PlatformResponseMapping>();
builder.Services.AddSingleton<IMapping<PlatformPatch, BlogPlatform>, PlatformPatchMapping>();
builder.Services.AddSingleton<IMapping<PlatformPatch, BlogPlatform, string>, PlatFormMapping>();

builder.Services.AddScoped<IRepository<BlogPlatform>, PlatformRepository>();

builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

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
