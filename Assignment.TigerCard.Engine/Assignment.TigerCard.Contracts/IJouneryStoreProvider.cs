using Assignment.TigerCard.Models;
using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.Contracts
{
    public interface IJouneryStoreProvider
    {
        void SaveJourneyDetails(Criteria criteria, Fare fare, Card card);
        List<JourneyDetails> GetListOfJourneyDetails(string tigerCardNumber, DateTime journeyDate);
    }
}
