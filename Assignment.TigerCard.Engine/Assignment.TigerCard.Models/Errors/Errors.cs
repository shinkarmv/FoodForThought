using System.Net;

namespace Assignment.TigerCard.Models.Errors
{
    public static class Errors
    {
        public static class ClientSide
        {
            public static BaseApplicationException ValidationFailure()
            {
                return new BaseApplicationException(ErrorCode.InvalidField, ErrorMessage.InvalidFieldValue, HttpStatusCode.BadRequest);
            }
            public static BaseApplicationException MissingMandatoryField(string fieldName)
            {
                return new BaseApplicationException(ErrorCode.MissingField, string.Format(ErrorMessage.MissingFieldValue, fieldName), HttpStatusCode.BadRequest);
            }
        }
    }
}
