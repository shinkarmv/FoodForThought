using Assignment.TigerCard.Models;

namespace Assignment.TigerCard.Contracts
{
    public interface IRuleProcessor
    {
        void Cap();

        Fare Peak(Window window, Zone boardingZone, Zone destinationZone);

    }
}
