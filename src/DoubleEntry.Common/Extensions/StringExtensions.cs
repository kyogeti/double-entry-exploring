namespace DoubleEntry.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text) && string.IsNullOrWhiteSpace(text); }

    }
}