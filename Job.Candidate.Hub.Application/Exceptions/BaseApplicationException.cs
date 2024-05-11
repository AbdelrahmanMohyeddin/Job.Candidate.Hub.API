namespace Job.Candidate.Hub.Application.Exceptions
{
    public class BaseApplicationException : Exception
    {
        public BaseApplicationException() { }

        public BaseApplicationException(string message)
            : base(message) { }

        public BaseApplicationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
