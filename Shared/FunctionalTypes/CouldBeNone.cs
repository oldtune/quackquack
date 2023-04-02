namespace Shared.FunctionalTypes;
public struct CouldBeNone<T>
{
    public T Value { get; }
    public bool HasValue { get; private set; }

    public CouldBeNone(T value)
    {
        if (value == null)
        {
            this.HasValue = false;
            return;
        }

        this.Value = value;
        this.HasValue = true;
    }

    public static CouldBeNone<T> CreateNone()
    {
        return new CouldBeNone<T> { HasValue = false };
    }

    public static CouldBeNone<T> CreateSome(T value)
    {
        return new CouldBeNone<T>(value);
    }
}

public struct None
{
    public static None Default = new None();
}