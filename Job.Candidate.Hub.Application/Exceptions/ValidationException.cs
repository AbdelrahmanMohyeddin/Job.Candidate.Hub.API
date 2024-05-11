using FluentValidation.Results;

namespace Job.Candidate.Hub.Application.Exceptions
{
    public class ValidationException : BaseApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException()
           : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(string message): base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }


        public ValidationException(params ValidationResult[] validationResults) :this()
        {
            Errors = validationResults
             .Where(r => r.Errors.Any())
             .SelectMany(r => r.Errors)
             .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
             .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        }

    }
}
