namespace Shared.FunctionalTypes;
public struct PositiveInteger
{
    public int Value { get; private set; }

    public static CouldBeNone<PositiveInteger> Make(int value)
    {
        if (value < 0)
        {
            return CouldBeNone<PositiveInteger>.CreateNone();
        }

        return new CouldBeNone<PositiveInteger>(new PositiveInteger(value));
    }

    private PositiveInteger(int value)
    {
        Value = value;
    }
}
