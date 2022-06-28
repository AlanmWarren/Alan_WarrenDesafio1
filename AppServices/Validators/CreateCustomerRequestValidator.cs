using Application.Models.Requests;
using FluentValidation;
using FluentValidation.Validators;
using Infrastructure.Extensions;
using System;

namespace Application.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(300)
                .Must(x => x.IsValidFullName());

            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(256)
                .EmailAddress(EmailValidationMode.Net4xRegex);

            RuleFor(x => x)
                .Must(x => x.Email == x.EmailConfirmation)
                .WithMessage("'Email' and 'EmailConfirmation' should be equals")
                .Must(x => x.EmailSms && !x.Whatsapp || !x.EmailSms && x.Whatsapp || x.EmailSms && x.Whatsapp)
                .WithMessage("At least one or both 'EmailSms' or/and 'Whatsapp' must be true");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .Must(IsValidCPF)
                .MinimumLength(11)
                .MaximumLength(14);

            RuleFor(x => x.Cellphone)
                .NotEmpty()
                .Length(11)
                .Must(x => x.IsValidNumber());

            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .Must(CheckIfCustomerIsHigherThanEighteenYearsOld)
                .WithMessage("Customer must be at least eighteen years old");

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(58)
                .Must(x => x.IsValidLetter());

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(58)
                .Must(x => x.IsValidLetter());

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .Length(8)
                .Must(x => x.IsValidNumber());

            RuleFor(x => x.Adress)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .Must(x => x.IsValidLetter());

            RuleFor(x => x.Number)
                .NotEmpty()
                .GreaterThan(0);
        }

        private static bool CheckIfCustomerIsHigherThanEighteenYearsOld(DateTime birthdate)
        {
            var dateTimeNow = DateTime.Now;
            if (dateTimeNow.Year - birthdate.Year > 18)
            {
                return true;
            }

            if (dateTimeNow.Year - birthdate.Year == 18)
            {
                if (birthdate.Month - dateTimeNow.Month < 0)
                {
                    return true;
                }
                else if (birthdate.Month - dateTimeNow.Month == 0)
                {
                    if (birthdate.Day <= dateTimeNow.Day)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsValidCPF(string cpf)
        {
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (!cpf.IsValidNumber()) return false;

            if (cpf.AllCharacteresArentEqualsToTheFirstCharacter()) return false;

            var firstDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 2; i++)
            {
                firstDigitAfterDash += cpf.ToIntAt(i) * (10 - i);
            }

            firstDigitAfterDash = (firstDigitAfterDash * 10) % 11;
            firstDigitAfterDash = firstDigitAfterDash == 10 ? 0 : firstDigitAfterDash;

            var secondDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 1; i++)
            {
                secondDigitAfterDash += cpf.ToIntAt(i) * (11 - i);
            }

            secondDigitAfterDash = (secondDigitAfterDash * 10) % 11;
            secondDigitAfterDash = secondDigitAfterDash == 10 ? 0 : secondDigitAfterDash;

            return firstDigitAfterDash == cpf.ToIntAt(^2) && secondDigitAfterDash == cpf.ToIntAt(^1);
        }
    }
}