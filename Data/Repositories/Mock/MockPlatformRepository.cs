// using System.Linq.Expressions;
// using Infrastructure;
// using Shared.FunctionalTypes;

// namespace Data.Repositories.Mock;
// public class MockPlatformRepository : IRepository<BlogPlatform>
// {
//     readonly IDateTimeProvider _dateTimeProvider;
//     readonly IUuidProvider _uuIdProvider;
//     public MockPlatformRepository(IUuidProvider uuidProvider,
//     IDateTimeProvider dateTimeProvider)
//     {
//         _uuIdProvider = uuidProvider;
//         _dateTimeProvider = dateTimeProvider;
//     }
//     public void Add(BlogPlatform obj)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<IEnumerable<BlogPlatform>> Filter(Expression<Func<BlogPlatform, bool>> filter)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<CouldBeNone<BlogPlatform>> FindById(string id)
//     {
//         throw new NotImplementedException();
//     }

//     public async Task<IEnumerable<BlogPlatform>> GetAll()
//     {
//         return new List<BlogPlatform>(){
//         new BlogPlatform{
//         Id = _uuIdProvider.GetNewUuid(),
//         CreatedDateUtc = _dateTimeProvider.CurrentUtcTime,
//         ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime,
//         Name = "Medium"
//         },
//         new BlogPlatform{
//             Id = _uuIdProvider.GetNewUuid(),
//             CreatedDateUtc = _dateTimeProvider.CurrentUtcTime,
//             ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime,
//             Name = "Dev.to"
//         }
//       };
//     }

//     public void Remove(BlogPlatform obj)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<CouldBeFailed> SaveChanges()
//     {
//         throw new NotImplementedException();
//     }

//     public void Update(BlogPlatform obj)
//     {
//         throw new NotImplementedException();
//     }
// }
