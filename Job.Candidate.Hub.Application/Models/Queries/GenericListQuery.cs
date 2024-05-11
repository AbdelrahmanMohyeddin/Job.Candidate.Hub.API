namespace Job.Candidate.Hub.Application.Models.Queries
{
    public class GenericListQuery<T> : BaseListQuery where T : class
    {
        public T? Filter { get; set; }

    }
}
