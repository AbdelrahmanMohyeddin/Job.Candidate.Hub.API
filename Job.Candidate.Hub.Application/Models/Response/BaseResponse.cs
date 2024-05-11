namespace Job.Candidate.Hub.Application.Models.Response
{   
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            Message = "Operation Completed Successfully";
        }

        public BaseResponse(string message) 
        {
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public IDictionary<string, string[]>? Errors { get; set; } 
    }
}
