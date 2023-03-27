using Data;
using Infrastructure;
using QuackQuack.Models;

namespace QuackQuack.Mappings;
public class PlatformPatchMapping : IMapping<PlatformPatch, BlogPlatform>
{
    readonly IDateTimeProvider _dateTimeProvider;
    public PlatformPatchMapping(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public BlogPlatform Map(PlatformPatch obj)
    {
        return new BlogPlatform
        {
            ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime,
            Name = obj.Name
        };
    }
}

public class PlatformResponseMapping : IMapping<BlogPlatform, PlatformResponse>
{
    public PlatformResponse Map(BlogPlatform obj)
    {
        return new PlatformResponse
        {
            Id = obj.Id
        };
    }
}

public class PlatFormMapping : IMapping<PlatformPatch, BlogPlatform, string>
{
    readonly IMapping<PlatformPatch, BlogPlatform> _internalMapping;

    public PlatFormMapping(IMapping<PlatformPatch, BlogPlatform> internalMapping)
    {
        _internalMapping = internalMapping;
    }

    public BlogPlatform Map(PlatformPatch obj, string id)
    {
        var result = _internalMapping.Map(obj);
        result.Id = id;

        return result;
    }
}