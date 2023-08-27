using CoreLayer.Messages.FluentValidationMessages;
using EntityLayer.Identity.ViewModes;
using FluentValidation;

namespace ServiceLayer.FluentValidation.Identity
{
    public class SignInVMValidation : AbstractValidator<SignInVM>
    {
        public SignInVMValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(GenericMessagesForFluentValidations.UseEmail())
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"));
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password"));
        }
    }
}
