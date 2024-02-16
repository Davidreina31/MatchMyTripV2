using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.commands.createActivityCommand
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(v => v.ActivityName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
