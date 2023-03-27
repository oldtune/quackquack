using Data;

public class PlatformRepository : BaseRepository<BlogPlatform>, IRepository<BlogPlatform>
{
    public PlatformRepository(PorfolioDbContext db) : base(db)
    { }
}