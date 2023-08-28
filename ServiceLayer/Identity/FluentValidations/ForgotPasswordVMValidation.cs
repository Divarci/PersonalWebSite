using EntityLayer.Identity.ViewModes;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.Identity.FluentValidations
{
    public class ForgotPasswordVMValidation : AbstractValidator<ForgotPasswordVM>
    {
        public ForgotPasswordVMValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(GenericMessagesForFluentValidations.UseEmail())
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"));
        }
    }
}
