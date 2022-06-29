using System;
using System.Linq;

namespace Infrastructure.Extensions
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
            if (AllCharacteresArentEqualsToTheFirstCharacter(letter)
                || letter.Trim() != letter
                || letter.Split(' ').Contains("")
                || letter.Split(' ').Any(_ => !char.IsUpper(_.First()))
                || letter.Replace(" ", string.Empty).Any(x => !char.IsLetter(x))) return false;

            return true;
        }

        public static string FormatCpf(this string cpf)
        {
            var cpfFormated = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            return cpfFormated;
        }

        public static bool IsValidFullName(this string fullName)
        {
            if (!fullName.IsValidLetter()) return false;

            string[] nameAndLastName = fullName.Split(' ');
            return nameAndLastName.Length > 1 && nameAndLastName.Length <= 7;
        }

        public static bool AllCharacteresArentEqualsToTheFirstCharacter(this string text)
        {
            return text.All(c => c.Equals(text.First()));
        }
    }
}
