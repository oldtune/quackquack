namespace Data;
public class BlogPost : IAuditable
{
    public int Id { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime PostedDate { set; get; }
    public string PlatformId { set; get; }
    public BlogPlatform BlogPlatform { set; get; }
    public string ProfileId { set; get; }
    public Profile Profile { set; get; }

    public DateTime? ModifiedDateUtc { get; set; }
    public DateTime CreatedDateUtc { get; set; }
}