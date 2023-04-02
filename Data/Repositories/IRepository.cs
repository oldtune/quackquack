using System.Linq.Expressions;
using Shared.FunctionalTypes;

public interface IRepository<T> where T : class
{
    Task<CouldBeNone<T>> FindById(string id);
    Task<IEnumerable<T>> GetAll();
    void Add(T obj);
    void Update(T obj);
    void Remove(T obj);
    Task<CouldBeFailed> SaveChanges();
    Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> filter);
    Task<CouldBeNone<T>> First(Expression<Func<T, bool>> expression = null);
}