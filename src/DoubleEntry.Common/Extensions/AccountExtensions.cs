using System;

namespace DoubleEntry.Common.Extensions
{
    public static class AccountExtensions
    {
        public static string ToAccountingFormat(this decimal value)
        {
            if (value < 0)
                return $"{Math.Round(value * -1, 2)} C";
            if(value > 0)
                return $"{Math.Round(value, 2)} D";

            return "0";
        }
    }
}