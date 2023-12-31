﻿using EntityLayer.WebApplication.ViewModels.HomePageViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.HomePageValidation
{
    public class HomePageUpdateValidation : AbstractValidator<HomePageUpdateVM>
    {
        public HomePageUpdateValidation()
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
        }
    }
}
