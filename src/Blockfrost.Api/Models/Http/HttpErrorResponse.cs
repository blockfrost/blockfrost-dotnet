using System.Collections.Generic;

namespace Blockfrost.Api
{
    public abstract class HttpErrorResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    public partial class BadRequestResponse : HttpErrorResponse
    {
    }

    public partial class ForbiddenResponse : HttpErrorResponse
    {
    }

    public partial class UnsupportedMediaTypeResponse : HttpErrorResponse
    {
    }

    public partial class TooManyRequestsResponse : HttpErrorResponse
    {
    }

    public partial class InternalServerErrorResponse : HttpErrorResponse
    {
    }

    public partial class NotFoundResponse : HttpErrorResponse
    {
    }
}