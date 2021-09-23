using System;

namespace Blockfrost.Api.Http
{
    /// <summary>Decorates a Get Method with the route</summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class GetAttribute : Attribute
    {
        public string Route { get; set; }
        public string Version { get; set; }
        /// <summar></summar>
        /// <param name="route">The OAS route</param>
        /// <param name="version">The OAS version</param>
        public GetAttribute(string route, string version)
        {
            Route = route;
            Version = version;
        }
    }
}
