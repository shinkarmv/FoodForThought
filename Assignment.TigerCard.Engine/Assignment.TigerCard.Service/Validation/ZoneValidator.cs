using FluentValidation;

namespace Assignment.TigerCard.Service.Validation
{
    public class ZoneValidator : AbstractValidator<Zone>
    {
        public ZoneValidator(string parent)
        {
            RuleFor(x => x.Id)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty();
            RuleFor(x => x.Name)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty();
            When(x => x.Stations.Count > 0,
                    () =>
                        RuleForEach(y => y.Stations)
                        .SetValidator(new StationValidator()));
        }
    }
}
