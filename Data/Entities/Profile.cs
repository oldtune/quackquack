namespace Data;
public class Profile : IEntity
{
    public string Id { set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public int YearOfBirth { set; get; }
    public string Education { set; get; }
    public string Location { set; get; }
    public string Gender { set; get; }
    public string Language { set; get; }
    public string AvatarUrl { set; get; }
    public List<Project> Projects { set; get; }
    public List<Company> Companies { set; get; }
    public List<BlogPlatform> BlogPlatforms { set; get; }
    public List<BlogPost> BlogPosts { set; get; }

    public DateTime? ModifiedDateUtc { get; set; }
    public DateTime CreatedDateUtc { get; set; }
}