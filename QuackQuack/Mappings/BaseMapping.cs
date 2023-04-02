// using QuackQuack.Mappings;

// public abstract class BaseMapping<T, TResult> : IMapping<T, TResult> where T : class, new() where TResult : class, new()
// {
//     public abstract TResult Map(T obj);

//     public IEnumerable<TResult> MapCollection(IEnumerable<T> collection)
//     {
//         return collection.Select(item => this.Map(item));
//     }
// }