using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Responses
{
    public class Response<TData>
    {


        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }

        [JsonConstructor]
        public Response()
        {
            _code = Configuration.DefaultStatusCode;
        }

        public TData? Data { get; set; }

        private int _code = Configuration.DefaultStatusCode;
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}
