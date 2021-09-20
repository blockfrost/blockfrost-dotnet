using System;

namespace Blockfrost.Api.Http
{
    /// <summary>Decorates a Get Method with the route</summary>
    [AttributeUsage(AttributeTargets.Method)]
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

