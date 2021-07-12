using Assignment.TigerCard.Models;
using System.Collections.Generic;

namespace Assignment.TigerCard.Contracts
{
    public interface IJouneryStoreProvider
    {
        JourneyDetails GetJourneyDetails(string journeyId, string tigerCardNumber);
        void SaveJourneyDetails(JourneyDetails journeyDetails);
        List<JourneyDetails> GetListOfJourneyDetails(string tigerCardNumber);
    }
}
