#nullable enable
using System;

namespace RssFeeder.Utils
{
    public class Validator
    {
        public static void NotNull(object? item, string? message = "The item cannot be null")
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), message);
            }
        }

        public static void NotNullOrEmpty(string? item, string? message = "The item cannot be null or empty")
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentNullException(nameof(item), message);
            }
        }
    }
}
