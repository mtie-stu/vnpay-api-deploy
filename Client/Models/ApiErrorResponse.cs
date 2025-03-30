using Newtonsoft.Json;

namespace Client.Models
{
    public class ApiErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public ErrorDetails Errors { get; set; } = new ErrorDetails();
    }

    public class ErrorDetails
    {
        [JsonProperty("$values")]
        public List<ApiErrorDetail> Values { get; set; } = new List<ApiErrorDetail>();
    }

    public class ApiErrorDetail
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }


}
