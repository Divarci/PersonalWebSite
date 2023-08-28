﻿using EntityLayer.WebApplication.ViewModels.ExperienceViewModel;
using FluentValidation;
using ServiceLayer._SharedFolder.Messages.FluentValidation;

namespace ServiceLayer.WebApplication.FluentValidations.ExperienceValidation
{
    public class ExperienceUpdateValidation : AbstractValidator<ExperienceUpdateVM>
    {
        public ExperienceUpdateValidation()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Title"))
               .MaximumLength(50).WithMessage(GenericMessagesForFluentValidations.MaximumLength("50"));
            RuleFor(x => x.Date)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Date"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Date"))
               .MaximumLength(30).WithMessage(GenericMessagesForFluentValidations.MaximumLength("30"));
            RuleFor(x => x.Location)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Location"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Location"))
               .MaximumLength(50).WithMessage(GenericMessagesForFluentValidations.MaximumLength("50"));
            RuleFor(x => x.Priorty)
               .NotEmpty().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Priority"))
               .NotNull().WithMessage(GenericMessagesForFluentValidations.EmptyNullMessage("Priority"))
               .Must(p => p < 1000).WithMessage(GenericMessagesForFluentValidations.MaximumNumber(999)); ;
        }
    }
}