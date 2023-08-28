using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SkillViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.SkillValidation
{
    public class SkillUpdateValidation : AbstractValidator<SkillUpdateVM>
    {
        public SkillUpdateValidation()
        {
            //Fact Validation (Child)
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .MaximumLength(50).WithMessage(GenericMessagesForFluentValidations.MaximumLength("50"));
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Value"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Value"))
                .Must(x => x < 100).WithMessage(GenericMessagesForFluentValidations.MaximumNumber(99));
        }
    }
}
