using EntityLayer.WebApplication.ViewModels.AboutMeViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.AboutMeValidation
{
    public class AboutMeAddValidation : AbstractValidator<AboutMeAddVM>
    {
        public AboutMeAddValidation()
        {
            //About Me Validation (Parent)
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Description"))
                .MaximumLength(1000).WithMessage(GenericMessagesForFluentValidations.MaximumLength("1000"));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
                .MaximumLength(50).WithMessage(GenericMessagesForFluentValidations.MaximumLength("50"));

            //Contact Validation (Child)
            RuleFor(x => x.Contact.Address)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Address"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Address"))
                .MaximumLength(250).WithMessage(GenericMessagesForFluentValidations.MaximumLength("250"));
            RuleFor(x => x.Contact.Email)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Email"))
                .MaximumLength(100).WithMessage(GenericMessagesForFluentValidations.MaximumLength("100"));
            RuleFor(x => x.Contact.Phone)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Phone"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Phone"))
                .MaximumLength(15).WithMessage(GenericMessagesForFluentValidations.MaximumLength("15"));
            RuleFor(x => x.Contact.LocationUrl)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Location"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Location"));

            //Fact Validation (Child)
            RuleFor(x => x.Fact.DaysOfStudy)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Days Of Study"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Days Of Study"))
                .Must(days => days < 10000).WithMessage(GenericMessagesForFluentValidations.MaximumNumber(9999));
            RuleFor(x => x.Fact.Project)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Projects"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Projects"))
                .Must(days => days < 1000).WithMessage(GenericMessagesForFluentValidations.MaximumNumber(999));
            RuleFor(x => x.Fact.CodingLanguage)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Coding Languages"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Coding Languages"))
                .Must(days => days < 100).WithMessage(GenericMessagesForFluentValidations.MaximumNumber(99));
            RuleFor(x => x.Fact.Certificate)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Certificates"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Certificates"))
                .Must(days => days < 100).WithMessage(GenericMessagesForFluentValidations.MaximumNumber(99));

            //SocialMedia Validation (Child)
            RuleFor(x => x.SocialMedia.Twitter)
                .MaximumLength(1500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("1500"));
            RuleFor(x => x.SocialMedia.GitHub)
                .MaximumLength(1500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("1500"));
            RuleFor(x => x.SocialMedia.Youtube)
                .MaximumLength(1500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("1500"));
            RuleFor(x => x.SocialMedia.LinkedIn)
                .MaximumLength(1500).WithMessage(GenericMessagesForFluentValidations.MaximumLength("1500"));

            //Photo Validation
            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"))
                .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Photo"));


        }
    }
}
