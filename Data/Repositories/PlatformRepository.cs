using Data;

public class PlatformRepository : BaseRepository<Platform>, IRepository<Platform>
{
    public PlatformRepository(PorfolioDbContext db) : base(db)
    { }
}