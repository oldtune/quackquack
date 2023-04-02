using Data;
using Microsoft.EntityFrameworkCore;

namespace QuackQuack.HostedServices;
public class DataSeedingHostedService : BackgroundService
{
    readonly IServiceProvider _serviceProvider;
    public DataSeedingHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PorfolioDbContext>();
        if (!await db.BlogPlatforms.AnyAsync())
        {
            var blogPlatforms = new List<BlogPlatform>{
                new BlogPlatform{

                }
            };
            db.BlogPlatforms.AddRange(blogPlatforms);
        }
    }
}