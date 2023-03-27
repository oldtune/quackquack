using Infrastructure;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    void Add(T obj);
    void Update(T obj);
    void Remove(T obj);
    Task<CouldBeFailed> SaveChanges();
}