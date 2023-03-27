using System;

namespace Infrastructure;
public struct CouldBeNull<T> where T : class
{
    public T Value { get; }
    public bool HasValue { get; }

    public CouldBeNull(T value)
    {
        if (value == null)
        {
            this.HasValue = false;
            return;
        }

        this.Value = value;
        this.HasValue = true;
    }
}