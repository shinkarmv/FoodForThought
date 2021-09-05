using Assignment.TigerCard.Models;
using System.Collections.Generic;

namespace Assignment.TigerCard.Rules
{
    public interface ICapProvider
    {
        bool IsCapApplicable(List<JourneyDetails> journeyList, CapLimits capLimits);
    }
}
