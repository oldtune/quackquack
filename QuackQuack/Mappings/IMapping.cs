namespace QuackQuack.Mappings;
public interface IMapping<T, TResult>
{
    TResult Map(T obj);
}