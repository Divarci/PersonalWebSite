using CoreLayer.Messages.FluentValidationMessages;
using EntityLayer.Identity.ViewModes;
using FluentValidation;

namespace ServiceLayer.FluentValidation.Identity
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordValidation()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password"));
            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password Confirm"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password Confirm"))
                .Equal(x => x.Password).WithMessage(GenericMessagesForFluentValidations.PasswordCompare());
        }
    }
}
