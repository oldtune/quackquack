using AutoMapper;

namespace Shared.Extensions;
public static class MappingExtensions
{
    public static IEnumerable<TResult> MapCollection<T, TResult>(this IMapper mapper, IEnumerable<T> inputCollection)
    {
        return inputCollection.Select(x => mapper.Map<TResult>(x));
    }

    public static TResult MapWithExternalValue<TResult>(this IMapper mapper, object src, Func<TResult, TResult> callback)
    {
        var result = mapper.Map<TResult>(src);
        return callback(result);
    }

    public static TResult MapWithExternalValue<TResult>(this IMapper mapper, object src, Action<TResult> callback)
    {
        var result = mapper.Map<TResult>(src);
        callback(result);
        return result;
    }
}