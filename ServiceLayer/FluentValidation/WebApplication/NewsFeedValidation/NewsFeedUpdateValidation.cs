using EntityLayer.WebApplication.ViewModels.NewsFeedVM;
using FluentValidation;
using ServiceLayer.Helpers.FluentValidationMessages;

namespace ServiceLayer.FluentValidation.WebApplication.NewsFeedValidation
{
    public class NewsFeedUpdateValidation : AbstractValidator<NewsFeedUpdateVM>
    {
        public NewsFeedUpdateValidation()
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

           
        }
    }
}
