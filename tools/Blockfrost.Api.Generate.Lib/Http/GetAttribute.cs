using System;

namespace Blockfrost.Api.Http
{
    /// <summary>Decorates a Get Method with the route</summary>
    public class GetAttribute : Attribute 
    {
        /// <summar></summar>
        /// <param name="route">The OAS route</param>
        /// <param name="version">The OAS version</param>
        public GetAttribute(string route, string version)
        {
        }
    }
}

