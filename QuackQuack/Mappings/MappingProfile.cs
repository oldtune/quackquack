
using Data;
using QuackQuack.Models;

namespace QuackQuack.Mappings;
public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<BlogPlatformPatch, BlogPlatform>();
        CreateMap<BlogPlatform, BlogPlatformResponse>();

        CreateMap<BlogPost, BlogPostResponse>();
        CreateMap<BlogPostPatch, BlogPost>();

        CreateMap<ProfilePatch, Profile>();
        CreateMap<Profile, ProfileResponse>();

        CreateMap<Project, ProjectResponse>();
        CreateMap<ProjectPatch, Project>();
    }
}