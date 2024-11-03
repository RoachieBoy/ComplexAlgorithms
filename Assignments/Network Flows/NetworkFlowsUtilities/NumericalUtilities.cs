namespace NetworkFlowsUtilities;

public static class NumericalUtilities
{
    /// <summary>
    ///     Gets the max value for a given numerical type.
    /// </summary>
    /// <typeparam name="T"> Value type. </typeparam>
    /// <returns> The max value of the given numerical type T. </returns>
    public static T MaxValue<T>()
    {
        return typeof(T) switch
        {
            var t when t == typeof(int) => (T)(object)int.MaxValue,
            var t when t == typeof(double) => (T)(object)double.MaxValue,
            var t when t == typeof(long) => (T)(object)long.MaxValue,
            var t when t == typeof(float) => (T)(object)float.MaxValue,
            var t when t == typeof(decimal) => (T)(object)decimal.MaxValue,
            var t when t == typeof(uint) => (T)(object)uint.MaxValue,
            _ => throw new NotSupportedException(typeof(T).Name)
        };
    }
}