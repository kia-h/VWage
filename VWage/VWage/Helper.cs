using System;
using System.Linq;

namespace VSalary.Console
{

    /// <summary>
    /// Simple helper class to do some checking on inputs before doing calculation
    /// </summary>
    public static class Helper
    {
        public static bool IsNumber(this string input)
        {
            return double.TryParse(input, out _);
        }

        public static bool IsPositive(this string input)
        {
            return Convert.ToDouble(input) > 0;
        }

        public static bool IsValidFrequency(this char input)
        {
            char[] allowedCharacters = { 'm', 'M', 'f', 'F', 'w', 'W' };
            return allowedCharacters.Contains(input);
        }
    }
}
