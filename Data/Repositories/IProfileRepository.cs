using Data;

public class ProfileRepository : BaseRepository<Profile>, IRepository<Profile>
{
    public ProfileRepository(PorfolioDbContext db) : base(db)
    { }
}