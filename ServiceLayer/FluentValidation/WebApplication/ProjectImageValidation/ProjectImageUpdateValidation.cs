using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
using FluentValidation;
using ServiceLayer.Helpers.FluentValidationMessages;

namespace ServiceLayer.FluentValidation.WebApplication.ProjectImageValidation
{
    public class ProjectImageUpdateValidation : AbstractValidator<ProjectImageUpdateVM>
    {
        public ProjectImageUpdateValidation()
        {
            RuleFor(x => x.Photo)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"));
        }
    }
}
