namespace QuackQuack.Mappings;
public interface IMapping<T, TResult>
{
    TResult Map(T obj);
}

public interface IMapping<T, TResult, TId>
{
    public TResult Map(T obj, TId id);
}
