using Assignment.TigerCard.Models;

namespace Assignment.TigerCard.Contracts
{
    public interface IJourneyComponent
    {
        Fare Commute(Criteria criteria, Card card);
    }
}
