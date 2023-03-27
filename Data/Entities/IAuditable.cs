public interface IAuditable
{
    public DateTime? ModifiedDateUtc { set; get; }
    public DateTime CreatedDateUtc { set; get; }
}