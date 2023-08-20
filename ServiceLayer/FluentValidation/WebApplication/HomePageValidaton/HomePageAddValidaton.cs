using EntityLayer.WebApplication.ViewModels.HomePageViewModel;
using FluentValidation;
using ServiceLayer.Helpers.FluentValidationMessages;

namespace ServiceLayer.FluentValidation.WebApplication.HomePageValidaton
{
    public class HomePageAddValidaton : AbstractValidator<HomePageAddVM>
    {
        public HomePageAddValidaton()
        {
            //Home Page Section
            RuleFor(x => x.FullName)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
               .MaximumLength(50).WithMessage(GenericMessagesForFluentValidations.MaximumLength("50"));
            RuleFor(x => x.VideoUrl)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Video Url"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Video Url"));
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
               .MaximumLength(500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("500"));

            //Photo Section
            RuleFor(x => x.PhotoResumeCv)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"));


        }
    }
}
