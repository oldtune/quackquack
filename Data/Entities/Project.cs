namespace Data;
public class Project
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public string Domain { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime? EndDate { set; get; }
    public string DemoLink { set; get; }
    public string? CompanyId { set; get; }
    public Company Company { set; get; }
}