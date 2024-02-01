using Humanizer;

namespace Ardi.Shared.Utilities;

public static class Pluralizer<T>
{
    public static string PluralizedTypeName => typeof(T).Name.Pluralize();
}
