using System;
using System.Net;

namespace Blockfrost.Api.Tests.Services
{
    public class ResponseConfig<TContent>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public Func<TContent> Content { get; set; }
    }
}
