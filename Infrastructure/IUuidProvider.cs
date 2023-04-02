namespace Infrastructure;

public interface IUuidProvider
{
    string GetNewUuid();
    string FormatHyphenUuid(string uuid);
    string RemoveHyphenUuid(string uuid);
}
