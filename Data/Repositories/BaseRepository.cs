using System.Linq.Expressions;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.FunctionalTypes;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    readonly ILogger<BaseRepository<T>> _logger;
    readonly PorfolioDbContext _db;

    public BaseRepository(PorfolioDbContext db)
    {
        _db = db;
    }

    public async Task<CouldBeNone<T>> FindById(string id)
    {
        var result = await _db.Set<T>().FindAsync(id);
        return new CouldBeNone<T>(result);
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
        _db.Set<T>().Attach(obj);
        _db.Entry(obj).State = EntityState.Deleted;
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

    public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> filter)
    {
        return await _db.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<CouldBeNone<T>> First(Expression<Func<T, bool>> expression = null)
    {
        T result = null;
        if (expression != null)
        {
            result = await _db.Set<T>().FirstOrDefaultAsync(expression);
        }
        else
        {
            result = await _db.Set<T>().FirstOrDefaultAsync();
        }

        if (result == null)
        {
            return CouldBeNone<T>.CreateNone();
        }

        return CouldBeNone<T>.CreateSome(result);
    }
}