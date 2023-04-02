namespace Shared.FunctionalTypes;
public struct PagingResult<T>
{
    public PositiveInteger PageIndex { get; }
    public PositiveInteger PageSize { get; }
    public IEnumerable<T> Data { get; }
}