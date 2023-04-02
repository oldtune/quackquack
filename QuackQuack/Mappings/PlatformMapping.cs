// using Data;
// using Infrastructure;
// using QuackQuack.Models;

// namespace QuackQuack.Mappings;
// public class PlatformPatchMapping : BaseMapping<BlogPlatformPatch, BlogPlatform>, IMapping<BlogPlatformPatch, BlogPlatform>
// {
//     readonly IDateTimeProvider _dateTimeProvider;
//     public PlatformPatchMapping(IDateTimeProvider dateTimeProvider)
//     {
//         _dateTimeProvider = dateTimeProvider;
//     }

//     public override BlogPlatform Map(BlogPlatformPatch obj)
//     {
//         return new BlogPlatform
//         {
//             ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime,
//             Name = obj.Name
//         };
//     }
// }

// public class PlatformResponseMapping : BaseMapping<BlogPlatform, BlogPlatformResponse>, IMapping<BlogPlatform, BlogPlatformResponse>
// {
//     public override BlogPlatformResponse Map(BlogPlatform obj)
//     {
//         return new BlogPlatformResponse
//         {
//             Id = obj.Id,
//             Name = obj.Name
//         };
//     }
// }

// public class PlatFormMapping : IMapping<BlogPlatformPatch, BlogPlatform, string>
// {
//     readonly IMapping<BlogPlatformPatch, BlogPlatform> _internalMapping;

//     public PlatFormMapping(IMapping<BlogPlatformPatch, BlogPlatform> internalMapping)
//     {
//         _internalMapping = internalMapping;
//     }

//     public BlogPlatform Map(BlogPlatformPatch obj, string id)
//     {
//         var result = _internalMapping.Map(obj);
//         result.Id = id;

//         return result;
//     }
// }