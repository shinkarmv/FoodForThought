using Assignment.TigerCard.Contracts;
using Assignment.TigerCard.Models;
using System;

namespace Assignment.TigerCard.Engine
{
    public class JourneyComponent : IJourneyComponent
    {
        private readonly IRuleProcessor _ruleProcessor;
        private readonly IJouneryStoreProvider _jouneryStoreProvider;
        private readonly IConfigurationProvider _configurationProvider;
        
        public JourneyComponent(IRuleProcessor ruleProcessor, IJouneryStoreProvider jouneryStoreProvider, 
            IConfigurationProvider configurationProvider)
        {
            _ruleProcessor = ruleProcessor;
            _jouneryStoreProvider = jouneryStoreProvider;
            _configurationProvider = configurationProvider;
        }
        public Fare Commute(Criteria criteria, Card card)
        {
            var journeyList = _jouneryStoreProvider.GetListOfJourneyDetails(card.Number);
            _ruleProcessor.Cap();
            var fare = _ruleProcessor.Peak(new Window
                                            {
                                                StartTime = criteria.StartTime,
                                                EndTime = criteria.StartTime
                                            },
                                            criteria.Source, criteria.Destination);
            JourneyDetails journeyDetails = PrepareJourneryDetails(criteria, fare);
            _jouneryStoreProvider.SaveJourneyDetails(journeyDetails);
            return fare;
        }

        private JourneyDetails PrepareJourneryDetails(Criteria criteria, Fare fare)
        {
            return new JourneyDetails
            {
                Criteria = criteria,
                Fare = fare,
                JourneyId = Guid.NewGuid().ToString()
            };
        }
    }
}
