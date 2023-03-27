namespace Infrastructure;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentDateTime => DateTime.Now;

    public DateTime CurrentUtcTime => DateTime.UtcNow;
}