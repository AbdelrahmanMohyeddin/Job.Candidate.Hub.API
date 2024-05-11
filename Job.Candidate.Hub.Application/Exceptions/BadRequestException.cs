namespace Job.Candidate.Hub.Application.Exceptions
{
    public class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}