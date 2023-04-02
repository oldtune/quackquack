using System;

namespace Shared.FunctionalTypes;
public struct CouldBeFailed
{
    public async static Task<CouldBeFailed> FromTask(Func<Task> func)
    {
        try
        {
            await func();
            return new CouldBeFailed
            {
                Failed = false
            };
        }
        catch (Exception ex)
        {
            return new CouldBeFailed
            {
                Exception = ex,
                Failed = true
            };
        }
    }

    public static CouldBeFailed From(Action func)
    {
        try
        {
            func();
            return new CouldBeFailed
            {
                Failed = false
            };
        }
        catch (Exception ex)
        {
            return new CouldBeFailed
            {
                Exception = ex,
                Failed = true
            };
        }
    }

    public bool Failed { get; init; }
    public Exception? Exception { get; init; }
}