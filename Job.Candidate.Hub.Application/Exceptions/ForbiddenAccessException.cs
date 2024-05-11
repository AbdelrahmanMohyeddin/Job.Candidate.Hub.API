namespace Job.Candidate.Hub.Application.Exceptions
{
    public class ForbiddenAccessException : BaseApplicationException
    {
        public ForbiddenAccessException() : base("You are not authorized to perform this action") { }
    }

}
