namespace Assignment.TigerCard.Service
{
    internal static class JourneyResponseTranslator
    {
        internal static JourneyResponse ToJourneyDataContract(this Models.Fare fare, Criteria criteria)
        {
            return new JourneyResponse
            {
                Fare = new Fare
                {
                    Amount = fare.Amount,
                    Description = fare.Description
                },
                Criteria = criteria
            };
        }
    }
}
