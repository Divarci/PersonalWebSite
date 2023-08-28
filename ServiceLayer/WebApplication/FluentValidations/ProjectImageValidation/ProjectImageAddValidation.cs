using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.ProjectImageValidation
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
