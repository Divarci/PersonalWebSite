using CoreLayer.Messages.FluentValidationMessages;
using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
using FluentValidation;

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
