using AutoMapper;

namespace Job.Candidate.Hub.Application.Models.Response
{
    public class GenericResponse<T> : BaseResponse
    {
        public GenericResponse() { }


        public GenericResponse(T result)
        {
            Result = result;
        }


        public GenericResponse(object source, IMapper mapper)
        {
            Result = mapper.Map<T>(source);
        }


        public virtual T? Result { get; set; }
    }
}
