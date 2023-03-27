using Data;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    readonly ILogger<BaseRepository<T>> _logger;
    readonly PorfolioDbContext _db;

    public BaseRepository(PorfolioDbContext db)
    {
        _db = db;
    }

    public void Add(T obj)
    {
        _db.Set<T>().Add(obj);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public void Remove(T obj)
    {
        _db.Set<T>().Remove(obj);
    }

    public void Update(T obj)
    {
        _db.Set<T>().Update(obj);
    }

    public async Task<CouldBeFailed> SaveChanges()
    {
        var func = async () => await _db.SaveChangesAsync();
        return await CouldBeFailed.FromTask(func);
    }
}