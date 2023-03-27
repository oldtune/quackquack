using Data;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QuackQuack.Mappings;
using QuackQuack.Models;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]/platform")]
public class PlatformController : ExtendedControllerBase
{
    readonly IDateTimeProvider _dateTimeProvider;
    readonly ILogger<PlatformController> _logger;
    readonly IRepository<BlogPlatform> _repo;
    readonly IMapping<PlatformPatch, BlogPlatform, string> _platformMapping;
    readonly IMapping<BlogPlatform, PlatformResponse> _platformResponseMapping;

    public PlatformController(ILogger<PlatformController> logger,
     IRepository<BlogPlatform> repo,
     IDateTimeProvider dateTimeProvider,
     IMapping<PlatformPatch, BlogPlatform, string> platformMapping,
     IMapping<BlogPlatform, PlatformResponse> platformResponseMapping)
    {
        _logger = logger;
        _repo = repo;
        _dateTimeProvider = dateTimeProvider;
        _platformMapping = platformMapping;
        _platformResponseMapping = platformResponseMapping;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlatform()
    {
        var result = _repo.GetAll();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPlatform(PlatformPatch model)
    {
        var platform = new BlogPlatform
        {
            CreatedDateUtc = _dateTimeProvider.CurrentUtcTime,
            ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime,
            Name = model.Name
        };

        _repo.Add(platform);
        var result = await _repo.SaveChanges();

        return DelegateCouldBeFailed(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlatform(PlatformPatch model, string id)
    {
        var platform = _platformMapping.Map(model, id);
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
