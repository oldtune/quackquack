namespace Data.Repositories;
public class BlogRepository : BaseRepository<BlogPost>, IRepository<BlogPost>
{
    public BlogRepository(PorfolioDbContext db) : base(db)
    {
    }
}