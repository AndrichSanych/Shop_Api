using BusinessLogic.DTOs;
using FluentValidation;

namespace BusinessLogic.Validators

{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            this.RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            this.RuleFor(x => x.Password)
               .NotEmpty();

            this.RuleFor(x => x.Birthdate)
               .NotEmpty()
               .LessThan(DateTime.Now).WithMessage("Birthday cannot be futura date.");





        }
    }
}
