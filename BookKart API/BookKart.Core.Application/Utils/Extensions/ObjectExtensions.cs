namespace BookKart.Core.Application.Utils.Extensions;

public static class ObjectExtensions
{
    public static bool IsNullOrEmpty<T>(this T value)
    {
        if (typeof(T) == typeof(string))
            return string.IsNullOrEmpty(value as string);

        return value == null || value.Equals(default(T));
    }

    public static bool IsNonStringClass(this Type type)
    {
        if (type == null || type == typeof(string) ||
          type.FullName.Contains("System.Collections.Generic."))
            return false;
        return type.IsClass;
    }
}