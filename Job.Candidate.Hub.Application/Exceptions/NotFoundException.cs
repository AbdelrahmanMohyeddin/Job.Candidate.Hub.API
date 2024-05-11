namespace Job.Candidate.Hub.Application.Exceptions
{
    public class NotFoundException : BaseApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {
        }
    }
}
