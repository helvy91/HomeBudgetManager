namespace HomeBudgetManager.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
            => string.IsNullOrEmpty(value);
    }
}
