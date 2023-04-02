using AutoMapper;
using Data;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QuackQuack.Models;
using Shared.Extensions;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogPostController : ExtendedControllerBase
{
    readonly IRepository<BlogPost> _repository;
    readonly IMapper _mapper;
    readonly IDateTimeProvider _dateTimeProvider;
    readonly IUuidProvider _uuidProvider;
    BlogPostController(IRepository<BlogPost> repository,
     IMapper mapper,
     IDateTimeProvider dateTimeProvider,
     IUuidProvider uuidProvider)
    {
        _mapper = mapper;
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
        _uuidProvider = uuidProvider;
    }
    readonly ILogger<BlogPostController> _logger;

    public BlogPostController(ILogger<BlogPostController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
        var result = await _repository.GetAll();
        _mapper.MapCollection<BlogPost, BlogPostResponse>(result);
        return Ok(result);
    }

    // [HttpGet("aggregate")]
    // public async Task<IActionResult> GetAllBlogPostsAggregate()
    // {
    //     var blogPost = await _repository.GetAll();
    //     var platforms = await _ 
    // }

    [HttpGet("{platformId}")]
    public async Task<IActionResult> FilterByPlatform(string platformId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddBlogPost(BlogPostPatch model)
    {
        var blogPost = _mapper.MapWithExternalValue<BlogPost>(model, (result) =>
        {
            result.Id = _uuidProvider.GetNewUuid();
            result.CreatedDateUtc = _dateTimeProvider.CurrentUtcTime;
            result.ModifiedDateUtc = _dateTimeProvider.CurrentUtcTime;
        });

        _repository.Add(blogPost);
        var result = await _repository.SaveChanges();

        return DelegateCouldBeFailed(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlogPost()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBlogPost()
    {
        return Ok();
    }
}
