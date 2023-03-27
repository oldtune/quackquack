namespace Infrastructure;
public interface IDateTimeProvider
{
    public DateTime CurrentDateTime { get; }
    public DateTime CurrentUtcTime { get; }
}
