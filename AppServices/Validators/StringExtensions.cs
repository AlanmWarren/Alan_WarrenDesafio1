using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.Validators
{
    public static class StringExtensions
    {
        public static int ToIntAt(this string value, Index index)
        {
            var indexValue = index.IsFromEnd
                ? value.Length - index.Value
                : index.Value;

            return (int)char.GetNumericValue(value, indexValue);
        }

        public static bool IsValidNumber(this string number)
        {
            return number.All(x => char.IsDigit(x));
        }

        public static bool IsValidLetter(this string letter)
        {
            string compareLetter = letter;
            letter = letter.Trim();

            if (compareLetter != letter) return false;

            string[] subs = letter.Split(' ');

            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i] == "") return false;

                if (subs.Length > 1)
                {
                    letter = subs[i];
                }
            }

            return letter.All(x => char.IsLetter(x));
        }        
    }
}
