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
            => number.All(x => char.IsDigit(x));

        public static bool IsValidText(this string text)
        {
            if (text.Trim() != text
                || text.Split(' ').Contains("")
                || text.Split(' ').Any(_ => !char.IsUpper(_.First()))) return false;

            text = text.Replace(" ", string.Empty);
            if (AllCharacteresArentEqualsToTheFirstCharacter(text)) return false;

            return text.All(x => char.IsLetter(x));
        }

        public static string FormatCpf(this string cpf)
        {
            var cpfFormated = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            return cpfFormated;
        }

        public static bool IsValidFullName(this string fullName)
        {
            if (!fullName.IsValidText()) return false;

            string[] nameAndLastName = fullName.Split(' ');
            return nameAndLastName.Length > 1 && nameAndLastName.Length <= 7;
        }

        public static bool AllCharacteresArentEqualsToTheFirstCharacter(this string field)
            => field.All(c => c.Equals(field.First()));
    }
}
