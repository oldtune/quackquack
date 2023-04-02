namespace QuackQuack.Models;

public class BlogPostResponse
{
    public int Id { set; get; }
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime PostedDate { set; get; }
    public string BlogPlatformId { set; get; }
    public string ProfileId { set; get; }

    public DateTime? ModifiedDateUtc { get; set; }
    public DateTime CreatedDateUtc { get; set; }
}
