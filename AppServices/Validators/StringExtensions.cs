using System.Text.RegularExpressions;

namespace Alan_WarrenDesafio1.Validators
{
    public static class StringExtensions
    {
        public static bool IsValidCPF(this string document)
        {
            var expression = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}";
            return Regex.Match(document, expression).Success;
        }

        public static bool IsValidCEP(this string cep)
        {
            var expression = "[0-9]{5}\\-?[0-9]{3}";
            return Regex.Match(cep, expression).Success;
        }

        public static bool IsValidCellphone(this string cellphone)
        {
            var expression = "[0-9]{2}?[0-9]{4}?[0-9]{4}";
            return Regex.Match(cellphone, expression).Success;
        }

        public static bool IsValidEmail(this string email)
        {
            var expression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.Match(email, expression).Success;
        }
    }
}
