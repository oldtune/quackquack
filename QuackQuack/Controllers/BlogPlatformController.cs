using AutoMapper;
using Data;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QuackQuack.Mappings;
using QuackQuack.Models;
using Shared.Extensions;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogPlatformController : ExtendedControllerBase
{
    readonly IDateTimeProvider _dateTimeProvider;
    readonly ILogger<BlogPlatformController> _logger;
    readonly IRepository<BlogPlatform> _repo;
    readonly IMapper _mapper;
    readonly IUuidProvider _uuidProvider;

    public BlogPlatformController(ILogger<BlogPlatformController> logger,
     IRepository<BlogPlatform> repo,
     IDateTimeProvider dateTimeProvider,
     IMapper mapper,
     IUuidProvider uuIdProvider)
    {
        _logger = logger;
        _repo = repo;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
        _uuidProvider = uuIdProvider;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlatform()
    {
        var platforms = await _repo.GetAll();
        var result = _mapper.MapCollection<BlogPlatform, BlogPlatformResponse>(platforms);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPlatform(BlogPlatformPatch model)
    {
        var platform = _mapper.MapWithExternalValue<BlogPlatform>(model,
         (result) =>
         {
             result.Id = _uuidProvider.GetNewUuid();
             result.ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime;
             result.CreatedDateUtc = _dateTimeProvider.CurrentDateTime;
         });

        _repo.Add(platform);
        var result = await _repo.SaveChanges();

        return DelegateCouldBeFailed(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlatform(BlogPlatformPatch model, string id)
    {
        var platform = _mapper.MapWithExternalValue<BlogPlatform>(model, (result) =>
        {
            result.Id = id;
            result.ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime;
        });

        _repo.Update(platform);
        var result = await _repo.SaveChanges();

        return DelegateCouldBeFailed(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlatform(string platformId)
    {
        var platform = await _repo.FindById(platformId);

        if (platform.HasValue)
        {
            _repo.Remove(platform.Value);
            var result = await _repo.SaveChanges();
            return DelegateCouldBeFailed(result);
        }
        return BadRequest();
    }
}
