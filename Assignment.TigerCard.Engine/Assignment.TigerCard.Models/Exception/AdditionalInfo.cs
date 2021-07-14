using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.TigerCard.Models
{
    [Serializable]
    public sealed class AdditionalInfo
    {
        public string Code { get; }
        public string Message { get; set; }

        public AdditionalInfo(string code, string message)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            Code = code;
            Message = message;
        }
    }
}
