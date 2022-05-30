using Application.DTOs;
using FluentValidation;
using Alan_WarrenDesafio1.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
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
                .Must(y => y.IsValidEmail())
                .WithMessage("Email is invalid, please try again");

            RuleFor(x => x)
                .Must(x => x.Email == x.EmailConfirmation)
                .WithMessage("Invalid email and email confirmation, please try again")
                .Must(x => (x.EmailSms && !x.Whatsapp) || (!x.EmailSms && x.Whatsapp) || (x.EmailSms && x.Whatsapp))
                .WithMessage("Tick at least one checkbox Email SMS or WhatsApp");

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

            RuleFor(x => x.Country)
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
                .Must(y => y.IsValidCEP())
                .WithMessage("Postal Code is invalid (warning: don't forget the pontuation, ex: 00000-00)");

            RuleFor(x => x.Adress)
                .NotEmpty()
                .WithMessage("Adress must not be null or empty");

            RuleFor(x => x.Number)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Number must not be null or empty");
        }

        private static bool CheckCustomerIsHigherThanEighteenYearsOld(DateTime birthdate)
        {
            var x = new DateTime(DateTime.Now.Year, birthdate.Month, birthdate.Day);
            return x.Year - birthdate.Year >= 18;
        }
    }
}