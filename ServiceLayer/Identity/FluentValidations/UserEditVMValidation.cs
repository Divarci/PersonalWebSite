using EntityLayer.Identity.ViewModes;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.Identity.FluentValidations
{
    public class UserEditVMValidation : AbstractValidator<UserEditVM>
    {
        public UserEditVMValidation()
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
            RuleFor(x => x.NewPasswordConfirm)
                .Equal(x => x.NewPassword).WithMessage(GenericMessagesForFluentValidations.PasswordCompare());
        }
    }
}
