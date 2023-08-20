using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;
using FluentValidation;
using ServiceLayer.Helpers.FluentValidationMessages;

namespace ServiceLayer.FluentValidation.WebApplication.ProjectCategoryValidation
{
    public class ProjectCategoryAddValidation : AbstractValidator<ProjectCategoryAddVM>
    {
        public ProjectCategoryAddValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
        }
    }
}
