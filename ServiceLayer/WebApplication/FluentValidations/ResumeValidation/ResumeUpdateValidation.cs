using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.ResumeValidation
{
    public class ResumeUpdateValidation : AbstractValidator<ResumeUpdateVM>
    {
        public ResumeUpdateValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .MaximumLength(75).WithMessage(GenericMessagesForFluentValidations.MaximumLength("75"));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .MaximumLength(50).WithMessage(GenericMessagesForFluentValidations.MaximumLength("50"));
        }
    }
}
