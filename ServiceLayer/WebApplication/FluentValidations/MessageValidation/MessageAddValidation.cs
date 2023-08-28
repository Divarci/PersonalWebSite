using EntityLayer.WebApplication.ViewModels.MessageViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.MessageValidation
{
    public class MessageAddValidation : AbstractValidator<MessageAddVM>
    {
        public MessageAddValidation()
        {
            RuleFor(x => x.Sender)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Your Name"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Your Name"))
                .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Subject"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Subject"))
                .MaximumLength(250).WithMessage(GenericMessagesForFluentValidations.MaximumLength("250"));
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .MaximumLength(1000).WithMessage(GenericMessagesForFluentValidations.MaximumLength("1000"));
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
            RuleFor(x => x.CatpchaConfirm)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password Confirm"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Password Confirm"))
                .Equal(x => x.CatpchaGenerated).WithMessage(GenericMessagesForFluentValidations.ImHumanCheck());
        }
    }
}
