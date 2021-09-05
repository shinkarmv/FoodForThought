using Assignment.TigerCard.Models.Errors;
using FluentValidation;

namespace Assignment.TigerCard.Service.Validation
{
    public static class Validations
    {
        public static void EnsureValid<TRequest>(TRequest request, IValidator<TRequest> validator)
        {
            var validationError = Errors.ClientSide.ValidationFailure();
            if (request == null)
            {
                throw validationError;
            }
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                foreach (var validationFailure in validationResult.Errors)
                {
                    validationError.AdditionalInfo.Add(new Models.AdditionalInfo(validationFailure.ErrorCode, validationFailure.ErrorMessage));
                }
                throw validationError;
            }
        }
    }
}
