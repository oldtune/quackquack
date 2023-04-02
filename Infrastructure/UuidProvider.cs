namespace Infrastructure;
public class UuidProvider : IUuidProvider
{
    public string FormatHyphenUuid(string uuid)
    {
        return $"{uuid.Substring(0, 8)}-{uuid.Substring(8, 4)}-{uuid.Substring(12, 4)}-{uuid.Substring(16, 4)}-{uuid.Substring(20, 12)}";
    }

    public string GetNewUuid()
    {
        return Guid.NewGuid().ToString();
    }

    public string RemoveHyphenUuid(string uuid)
    {
        return uuid.Remove('-');
    }
}
