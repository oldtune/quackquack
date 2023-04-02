namespace QuackQuack.Models;

public class BlogPostPatch
{
    public string Title { set; get; }
    public string Description { set; get; }
    public DateTime PostedDate { set; get; }
    public string BlogPlatformId { set; get; }
    public string ProfileId { set; get; }
}
