using Microsoft.EntityFrameworkCore;

namespace Data;
public class PorfolioDbContext : DbContext
{
    public PorfolioDbContext(DbContextOptions<PorfolioDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Profile> Profiles { set; get; }
    public DbSet<BlogPost> BlogPosts { set; get; }
    public DbSet<BlogPlatform> BlogPlatforms { set; get; }
    public DbSet<Project> Projects { set; get; }
    public DbSet<Company> Companies { set; get; }
}
