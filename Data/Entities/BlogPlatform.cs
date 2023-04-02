namespace Data;
public class BlogPlatform : IEntity
{
    public string Id { set; get; }
    public string Name { set; get; }
    public ICollection<BlogPost> Posts { set; get; }
    public int? CompanyId { set; get; }
    public Company Company { set; get; }
    public DateTime? ModifiedDateUtc { set; get; }
    public DateTime CreatedDateUtc { get; set; }
}
