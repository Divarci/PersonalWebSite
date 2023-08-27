using CoreLayer.Messages.FluentValidationMessages;
using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.ProjectImageValidation
{
    public class ProjectImageAddValidation : AbstractValidator<ProjectImageAddVM>
    {
        public ProjectImageAddValidation()
        {
            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"));
        }
    }
}
