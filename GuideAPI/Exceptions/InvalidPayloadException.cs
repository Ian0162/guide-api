using FluentValidation.Results;

namespace GuideAPI.Exceptions
{
    public class InvalidPayloadException : Exception
    {
        public InvalidPayloadException(string message): base(message) { }

        public InvalidPayloadException(string message, int code, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
