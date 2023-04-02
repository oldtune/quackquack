using AutoMapper;
using Data;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QuackQuack.Models;
using Shared.Extensions;
using AutoMapperProfile = AutoMapper.Profile;
using EntityProfile = Data.Profile;

namespace QuackQuack.Controllers;
[ApiController]
[Route("[controller]")]
public class ProfileController : ExtendedControllerBase
{
    readonly IRepository<EntityProfile> _repository;
    readonly ILogger<ProfileController> _logger;
    readonly IDateTimeProvider _dateTimeProvider;
    readonly IUuidProvider _uuidProvider;
    readonly IMapper _mapper;

    public ProfileController(ILogger<ProfileController> logger,
    IMapper mapper,
    IRepository<EntityProfile> repository,
    IDateTimeProvider dateTimeProvider,
    IUuidProvider uuidProvider)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var profile = await _repository.First();
        return DelegateCouldBeNone<EntityProfile, ProfileResponse>(profile, (r) => _mapper.Map<ProfileResponse>(r));
    }

    [HttpPut("{profileId}")]
    public async Task<IActionResult> UpdateProfile(ProfilePatch model)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddProfile(ProfilePatch model)
    {
        var profile = _mapper.MapWithExternalValue<EntityProfile>(model, (r) =>
        {
            r.Id = _uuidProvider.GetNewUuid();
            r.ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime;
            r.CreatedDateUtc = _dateTimeProvider.CurrentUtcTime;
        });
        _repository.Add(profile);
        var result = await _repository.SaveChanges();

        return DelegateCouldBeFailed(result);
    }
}
