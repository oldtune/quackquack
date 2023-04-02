// using Data;
// using QuackQuack.Models;

// namespace QuackQuack.Mappings;
// public class BlogPatchMapping : BaseMapping<BlogPostPatch, BlogPost>, IMapping<BlogPostPatch, BlogPost>
// {
//     public override BlogPost Map(BlogPostPatch obj)
//     {
//         return new BlogPost
//         {
//             BlogPlatformId = obj.BlogPlatformId,
//             Description = obj.Description,
//             PostedDate = obj.PostedDate,
//             ProfileId = obj.ProfileId,
//             Title = obj.Title
//         };
//     }
// }

// public class BlogResponseMapping : BaseMapping<BlogPost, BlogPostResponse>, IMapping<BlogPost, BlogPostResponse>
// {
//     public override BlogPostResponse Map(BlogPost obj)
//     {
//         return new BlogPostResponse
//         {
//             BlogPlatformId = obj.BlogPlatformId,
//             CreatedDateUtc = obj.CreatedDateUtc,
//             Description = obj.Description,
//             Id = obj.Id,
//             ModifiedDateUtc = obj.ModifiedDateUtc,
//             PostedDate = obj.PostedDate,
//             ProfileId = obj.ProfileId,
//             Title = obj.Title
//         };
//     }
// }