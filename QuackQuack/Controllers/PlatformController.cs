using Data;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QuackQuack.Models;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformController : ExtendedControllerBase
{
    readonly IDateTimeProvider _dateTimeProvider;
    readonly ILogger<PlatformController> _logger;
    readonly IRepository<Platform> _repo;

    public PlatformController(ILogger<PlatformController> logger,
     IRepository<Platform> repo,
     IDateTimeProvider dateTimeProvider)
    {
        _logger = logger;
        _repo = repo;
        _dateTimeProvider = dateTimeProvider;
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
        var platform = new Platform
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
        var platform = new Platform
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePlatform(string platform)
    {
        return Ok();
    }
}
