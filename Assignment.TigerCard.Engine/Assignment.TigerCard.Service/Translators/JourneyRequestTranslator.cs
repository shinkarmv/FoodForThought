using System.Linq;

namespace Assignment.TigerCard.Service
{
    internal static class JourneyRequestTranslator
    {
        internal static Models.Criteria ToCriteriaModel(this Criteria criteria)
        {
            return new Models.Criteria
            {
                StartTime = criteria.StartTime,
                Destination = criteria.Destination.ToDestinationModel(),
                Source = criteria.Source.ToDestinationModel()
            };
        }

        internal static Models.Zone ToDestinationModel(this Zone zone)
        {
            Models.Zone destination = new Models.Zone
            {
                Id = zone.Id,
                Name = zone.Name,
            };
            destination.Stations.AddRange(zone.Stations.Select(x => x.ToStation()));
            return destination;
        }

        internal static Models.Station ToStation(this Station station)
        {
            return new Models.Station
            {
                Code = station.Code,
                Name = station.Name
            };
        }


        internal static Models.Card ToCardModel(this TigerCard tigerCard)
        {
            return new Models.Card
            {
                Name = tigerCard.Name,
                Number = tigerCard.Number,
                Balance = new Models.Balance
                {
                    Amount = tigerCard.Balance.Amount,
                    Currency = tigerCard.Balance.Currency
                }
            };
        }
    }
}
