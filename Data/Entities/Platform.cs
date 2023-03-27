namespace Data;
public class BlogPlatform : IAuditable
{
    public string Id { set; get; }
    public string Name { set; get; }
    public DateTime? ModifiedDateUtc { set; get; }
    public DateTime CreatedDateUtc { get; set; }
}