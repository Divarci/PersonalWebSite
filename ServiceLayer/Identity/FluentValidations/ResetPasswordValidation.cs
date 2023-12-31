﻿using EntityLayer.Identity.ViewModes;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.Identity.FluentValidations
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
