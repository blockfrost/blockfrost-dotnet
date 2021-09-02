using System;

namespace Blockfrost.Api.Http
{
    /// <summary>Decorates a Post Method with the route</summary>
    public class PostAttribute : Attribute 
    {
        /// <summar></summar>
        /// <param name="route">The OAS route</param>
        /// <param name="version">The OAS version</param>
        public PostAttribute(string route, string version)
        {
        }
    }
}

