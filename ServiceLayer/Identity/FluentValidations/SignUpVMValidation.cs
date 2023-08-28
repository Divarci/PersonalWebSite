using EntityLayer.Identity.ViewModes;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.Identity.FluentValidations
{
    public class SignUpVMValidation : AbstractValidator<SignUpVM>
    {
        public SignUpVMValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Username"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Username"));
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(GenericMessagesForFluentValidations.UseEmail())
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"));
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password"));
            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password Confirm"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password Confirm"))
                .Equal(x => x.Password).WithMessage(GenericMessagesForFluentValidations.PasswordCompare());
            RuleFor(x => x.TermsConditions)
                .Must(x => x == true).WithMessage(GenericMessagesForFluentValidations.AcceptTerms());


        }
    }
}
