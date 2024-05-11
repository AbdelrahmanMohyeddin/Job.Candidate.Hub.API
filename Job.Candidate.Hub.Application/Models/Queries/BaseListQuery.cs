namespace Job.Candidate.Hub.Application.Models.Queries
{
    public class BaseListQuery
    {
        public int PageSize { get; set; } = 1000;

        public int PageNo { get; set; } = 1;
    }
}
