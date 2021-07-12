using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Models;
using System;

namespace Assignment.TigerCard.Engine
{
    public class JourneyComponent : IJourneyComponent
    {
        private readonly IRuleProcessor _ruleProcessor;
        private readonly IJouneryStoreProvider _jouneryStoreProvider;
        
        public JourneyComponent(IRuleProcessor ruleProcessor, IJouneryStoreProvider jouneryStoreProvider)
        {
            _ruleProcessor = ruleProcessor;
            _jouneryStoreProvider = jouneryStoreProvider;
        }
        public Fare Commute(Criteria criteria, Card card)
        {
            Fare fare = new Fare
            {
                Amount = 0.0m,
                Description = "Cap Applicable"
            };
            var journeyList = _jouneryStoreProvider.GetListOfJourneyDetails(card.Number,  criteria.StartTime);
            var isCapApplicable = _ruleProcessor.Cap(journeyList);
            if (!isCapApplicable)
            {
                fare = _ruleProcessor.Peak(criteria.StartTime, criteria.Source, criteria.Destination);
            }
            _jouneryStoreProvider.SaveJourneyDetails(criteria, fare, card);
            return fare;
        }

    }
}
