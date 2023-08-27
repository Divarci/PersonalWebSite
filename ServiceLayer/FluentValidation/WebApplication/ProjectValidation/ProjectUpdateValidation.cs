using CoreLayer.Messages.FluentValidationMessages;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.ProjectValidation
{
    public class ProjectUpdateValidation : AbstractValidator<ProjectUpdateVM>
    {
        public ProjectUpdateValidation()
        {
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
               .MaximumLength(2500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("2500"));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
            RuleFor(x => x.ProjectDate)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Project Date"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Project Date"))
                .MaximumLength(10).WithMessage(GenericMessagesForFluentValidations.MaximumLength("10"));
        }
    }
}
