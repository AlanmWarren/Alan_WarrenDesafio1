﻿using Alan_WarrenDesafio1.Models;
using System.Text.RegularExpressions;

namespace Alan_WarrenDesafio1.Validators
{
    public static class StringExtensions
    {
        public static bool IsValidDocument(this string document) 
        {
            var expression = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}";
            return Regex.Match(document, expression).Success;

        }
    }
}
