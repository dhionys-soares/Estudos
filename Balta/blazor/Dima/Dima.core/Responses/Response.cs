using System.Text.Json.Serialization;

namespace Dima.core.Responses
{
    public class Response<T>
    {
        private readonly int _code;

        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;
        

        public Response(T? data, int code = 200, string? message = null)
        {
            _code = code;
            Data = data;
            Message = message;
        }
        public T? Data { get; set; }
        public string? Message { get; set; }
        
        [JsonIgnore]
        public bool IsSucess => _code is >= 200 and <= 299;
    }
}
