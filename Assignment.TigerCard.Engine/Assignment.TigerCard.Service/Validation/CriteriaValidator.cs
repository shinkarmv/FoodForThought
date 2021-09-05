using FluentValidation;

namespace Assignment.TigerCard.Service.Validation
{
    public class CriteriaValidator : AbstractValidator<Criteria>
    {
        public CriteriaValidator(string parent)
        {
            RuleFor(x => x.Destination)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty()
                    .SetValidator(new ZoneValidator("destination"));

            RuleFor(x => x.StartTime)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.Source)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty()
                    .SetValidator(new ZoneValidator("source"));
        }
    }
}
