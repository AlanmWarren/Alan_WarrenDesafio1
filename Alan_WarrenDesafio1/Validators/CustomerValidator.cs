
using Alan_WarrenDesafio1.Models;
using FluentValidation;

namespace Alan_WarrenDesafio1.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                     .WithMessage("Full name must not be null or empty")
                .MinimumLength(3)
                     .WithMessage("Full name length must be more than 3 digits")
                .MaximumLength(50)
                     .WithMessage("Full name length must cannot have more than 50 digits");

            RuleFor(c => c.Email)
               .NotEmpty()
                    .WithMessage("Email must not be null or empty")
               .MinimumLength(10)
                    .WithMessage("Email length must be more than 10")
               .MaximumLength(256)
                    .WithMessage("Email length must cannot have more than 256 digits")
                .EmailAddress()
                    .WithMessage("Email is invalid, please try again");

            RuleFor(c => c.EmailConfirmation)
               .NotEmpty()
                    .WithMessage("Email Confirmation must not be null or empty")
               .MinimumLength(10)
                    .WithMessage("Email Confirmation length must be more than 10 digits")
               .MaximumLength(256)
                    .WithMessage("Email Confirmation length must cannot have more than 256 digits")
                .EmailAddress()
                    .WithMessage("Email Confirmation is invalid, please try again");

            RuleFor(c => c.Cpf)
               .NotEmpty()
                    .WithMessage("Cpf must not be null or empty")
               .Length(14)
                    .WithMessage("Cpf length must contain 14 digits with the pontuation (warning: don't forget the pontuation, ex: 000.000.000-00)")
               .Must(d => d.IsValidDocument())
                    .WithMessage("Document is invalid, please try again (warning: don't forget the pontuation, ex: 000.000.000-00)");

            RuleFor(c => c.Cellphone)
               .NotEmpty()
                    .WithMessage("Cellphone must not be null or empty")
               .Length(11)
                    .WithMessage("Cellphone must have 11 digits");

            RuleFor(c => c.Birthdate)
                .NotEmpty()
                    .WithMessage("Birthdate must not be null or empty");

            RuleFor(c => c.Country)
               .NotEmpty()
                    .WithMessage("Country must not be null or empty")
               .MaximumLength(58)
                    .WithMessage("Country must cannot have more than 58 digits");

            RuleFor(c => c.City)
              .NotEmpty()
                    .WithMessage("City must not be null or empty")
              .MaximumLength(58)
                    .WithMessage("City must cannot have more than 58 digits");

            RuleFor(c => c.PostalCode)
              .NotEmpty()
                    .WithMessage("Postal Code must not be null or empty")
              .Length(9)
                    .WithMessage("Postal Code length must have 8 digits (warning: don't forget the pontuation, ex: 00000-00)")
              .Must(p => p.IsValidCEP())
                    .WithMessage("Postal Code is invalid (warning: don't forget the pontuation, ex: 00000-00)");

            RuleFor(c => c.Adress)
              .NotEmpty()
                    .WithMessage("Adress must not be null or empty");

            RuleFor(c => c.Number)
              .NotEmpty()
                    .WithMessage("Number must not be null or empty");

            
        }
    }
}
