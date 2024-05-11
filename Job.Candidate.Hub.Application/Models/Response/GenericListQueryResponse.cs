namespace Job.Candidate.Hub.Application.Models.Response
{
    public class GenericListQueryResponse <T>: BaseResponse
    {
        public int ItemCount { get; set; }

        public IEnumerable<T> Result { get; set; }


        public GenericListQueryResponse(IEnumerable<T> result, int itemCount)
        {
            ItemCount = itemCount;
            Result = result;
        }
    }
}
