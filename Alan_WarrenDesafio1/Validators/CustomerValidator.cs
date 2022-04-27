

using Alan_WarrenDesafio1.Models;
using FluentValidation;

namespace Alan_WarrenDesafio1.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                    .WithMessage("ID must not be 0");

            RuleFor(c => c.FullName)
                .NotEmpty()
                    .WithMessage("Full name must not be null or empty")
                .MinimumLength(5)
                    .WithMessage("Full name length must be more than 5");

            RuleFor(c => c.Email)
               .NotEmpty()
                   .WithMessage("Email must not be null or empty")
               .MinimumLength(10)
                   .WithMessage("Email length must be more than 10");

            RuleFor(c => c.EmailConfirmation)
               .NotEmpty()              
                   .WithMessage("EmailConfirmation must not be null or empty")
               .MinimumLength(5)
                   .WithMessage("EmailConfirmation length must be more than 5");
            
            RuleFor(c => c.Cpf)
               .NotEmpty()
                   .WithMessage("Cpf must not be null or empty")
               .MinimumLength(11)
                   .WithMessage("Cpf length must be more than 11")
               .Must(d => d.IsValidDocument())
                    .WithMessage("Document is invalid");
               
            RuleFor(c => c.Cellphone)
               .NotEmpty()
                   .WithMessage("Cellphone must not be null or empty");

            RuleFor(c => c.Country)
               .NotEmpty()
                   .WithMessage("Country must not be null or empty");

            RuleFor(c => c.City)
              .NotEmpty()
                  .WithMessage("City must not be null or empty");

            RuleFor(c => c.PostalCode)
              .NotEmpty()
                  .WithMessage("PostalCode must not be null or empty");

            RuleFor(c => c.Adress)
              .NotEmpty()
                  .WithMessage("Adress must not be null or empty");

            RuleFor(c => c.Number)
              .NotEmpty()
                  .WithMessage("Number must not be null or empty");

        }
    }
}
