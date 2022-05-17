using Alan_WarrenDesafio1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alan_WarrenDesafio1.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name must not be null or empty")
                .MinimumLength(2)
                .WithMessage("Full name length must be more than 2 digits")
                .MaximumLength(300)
                .WithMessage("Full name length must cannot have more than 50 digits");

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage("Email must not be null or empty")
               .MinimumLength(9)
               .WithMessage("Email length must be more than 9 digits")
               .MaximumLength(256)
               .WithMessage("Email length must cannot have more than 256 digits")
               .EmailAddress()
               .WithMessage("Email is invalid, please try again");

            RuleFor(x => x.EmailConfirmation)
                .NotEmpty()
                .WithMessage("Email Confirmation must not be null or empty")
                .MinimumLength(9)
                .WithMessage("Email Confirmation length must be more than 9 digits")
                .MaximumLength(256)
                .WithMessage("Email Confirmation length must cannot have more than 256 digits")
                .EmailAddress()
                .WithMessage("Email Confirmation is invalid, please try again");

            RuleFor(x => x)
                .Must(x => x.Email == x.EmailConfirmation)
                .WithMessage("Invalid email and email confirmation, please try again");

            RuleFor(x => x.Cpf)
               .NotEmpty()
               .WithMessage("Cpf must not be null or empty")
               .Length(14)
               .WithMessage("Cpf length must contain 14 digits with the pontuation (warning: don't forget the pontuation, ex: 000.000.000-00)")
               .Must(x => x.IsValidCPF())
               .WithMessage("Document is invalid, please try again (warning: don't forget the pontuation, ex: 000.000.000-00)");

            RuleFor(x => x.Cellphone)
               .NotEmpty()
               .WithMessage("Cellphone must not be null or empty")
               .Length(11)
               .WithMessage("Cellphone must have 11 digits")
               .Must(x => x.IsValidCellphone())
               .WithMessage("Cellphone is invalid, please try again");

            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .WithMessage("Birthdate must not be null or empty")
                .Must(y => CheckCustomerIsHigherThanEighteenYearsOld(y))
                .WithMessage("The customer cannot be under 18 years of age");

            RuleFor(c => c.Country)
               .NotEmpty()
               .WithMessage("Country must not be null or empty")
               .MaximumLength(58)
               .WithMessage("Country must cannot have more than 58 digits");

            RuleFor(x => x.City)
              .NotEmpty()
              .WithMessage("City must not be null or empty")
              .MaximumLength(58)
              .WithMessage("City must cannot have more than 58 digits");

            RuleFor(x => x.PostalCode)
              .NotEmpty()
              .WithMessage("Postal Code must not be null or empty")
              .Length(9)
              .WithMessage("Postal Code length must have 8 digits (warning: don't forget the pontuation, ex: 00000-00)")
              .Must(x => x.IsValidCEP())
              .WithMessage("Postal Code is invalid (warning: don't forget the pontuation, ex: 00000-00)");

            RuleFor(x => x.Adress)
              .NotEmpty()
              .WithMessage("Adress must not be null or empty");

            RuleFor(x => x.Number)
              .NotEmpty()
              .WithMessage("Number must not be null or empty");
        }
        
        public static bool CheckCustomerIsHigherThanEighteenYearsOld(DateTime birthdate)
        {
            var x = new DateTime(DateTime.Now.Year, birthdate.Month, birthdate.Day);
            var diff = x.Year - birthdate.Year;
            return diff >= 18;
        }
    }
}