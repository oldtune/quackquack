namespace Data;
public class Company : IEntity
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public string Domain { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime? EndDate { set; get; }
    public ICollection<Project> Projects { set; get; } = new List<Project>();
    public DateTime? ModifiedDateUtc { get; set; }
    public DateTime CreatedDateUtc { get; set; }
}