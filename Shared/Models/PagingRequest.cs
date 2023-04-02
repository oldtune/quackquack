using Shared.FunctionalTypes;

namespace Shared.Models;
public struct PagingRequest
{
    public PositiveInteger PageIndex { get; }
    public PositiveInteger PageSize { get; }
}
