using FluentValidation;

namespace Assignment.TigerCard.Service.Validation
{
    public class JourneyRequestValidation : AbstractValidator<JourneyRequest>
    {
        public JourneyRequestValidation()
        {
            RuleFor(x => x.Criteria)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty()
                    .SetValidator(new CriteriaValidator("criteria"));
        }
    }
}
