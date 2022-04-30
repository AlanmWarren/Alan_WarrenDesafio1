
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
                .MinimumLength(4)
                .MaximumLength(30)
                     .WithMessage("Full name length must be more than 5");

            RuleFor(c => c.Email)
               .NotEmpty()
                    .WithMessage("Email must not be null or empty")
               .MinimumLength(10)
               .MaximumLength(256)
                    .WithMessage("Email length must be more than 10")
                .EmailAddress()
                    .WithMessage("Email is invalid, please try again");

            RuleFor(c => c.EmailConfirmation)
               .NotEmpty()
                    .WithMessage("EmailConfirmation must not be null or empty")
               .MinimumLength(10)
               .MaximumLength(256)
                    .WithMessage("EmailConfirmation length must be more than 5")
                .EmailAddress()
                    .WithMessage("Email confirmation is invalid, please try again");

            RuleFor(c => c.Cpf)
               .NotEmpty()
                    .WithMessage("Cpf must not be null or empty")
               .Length(14)
                    .WithMessage("Cpf length must contain 11 digits (warning: don't forget the score)")
               .Must(d => d.IsValidDocument())
                    .WithMessage("Document is invalid, please try again");

            RuleFor(c => c.Cellphone)
               .NotEmpty()
                    .WithMessage("Cellphone must not be null or empty")
               .Length(11)
                    .WithMessage("Cellphone must have 11 digits");


            RuleFor(c => c.Country)
               .NotEmpty()
                    .WithMessage("Country must not be null or empty");

            RuleFor(c => c.City)
              .NotEmpty()
                    .WithMessage("City must not be null or empty")
              .MaximumLength(58)
                    .WithMessage("City must cannot have more than 58 digits");

            RuleFor(c => c.PostalCode)
              .NotEmpty()
                    .WithMessage("PostalCode must not be null or empty");

            RuleFor(c => c.Adress)
              .NotEmpty()
                    .WithMessage("Adress must not be null or empty");

            RuleFor(c => c.Number)
              .NotEmpty()
                    .WithMessage("Number must not be null or empty");

            RuleFor(c => c.Birthdate)
                .NotEmpty()
                    .WithMessage("Birthdate must not be null or empty");
        }
    }
}
