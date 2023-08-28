using EntityLayer.Identity.ViewModes;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.Identity.FluentValidations
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
