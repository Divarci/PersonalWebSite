using CoreLayer.Messages.FluentValidationMessages;
using EntityLayer.WebApplication.ViewModels.NewsFeedVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.NewsFeedValidation
{
    public class NewsFeedAddValidation : AbstractValidator<NewsFeedAddVM>
    {
        public NewsFeedAddValidation()
        {
            //Newsfeed Validation
            RuleFor(x => x.Title)
              .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
              .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
              .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
            RuleFor(x => x.Description)
              .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
              .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
              .MaximumLength(2500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("2500"));

            //Photo Validation
            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"));

        }
    }
}
