using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.TigerCard.Service.Validation
{
    public class StationValidator : AbstractValidator<Station>
    {
        public StationValidator()
        {
            RuleFor(x => x.Code)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty();
            RuleFor(x => x.Name )
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
