using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Service.Validation;

namespace Assignment.TigerCard.Service
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyComponent _journeyComponent;
        public JourneyService(IJourneyComponent journeyComponent)
        {
            _journeyComponent = journeyComponent;
        }

        public JourneyResponse Journey(JourneyRequest journeyRequest)
        {
            Validations.EnsureValid(journeyRequest, new JourneyRequestValidation());
            var criteria = journeyRequest.Criteria.ToCriteriaModel();
            var card = journeyRequest.TigerCard.ToCardModel();
            var fare = _journeyComponent.Commute(criteria, card);
            return fare.ToJourneyDataContract(journeyRequest.Criteria);
        }
    }
}
