using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    /// <summary>
    /// Specifies basic functionality for services interacting with the Blockfrost API
    /// </summary>
    public partial interface IBlockfrostService
    {
        string Network { get; }
        string BaseUrl { get; set; }
        bool ReadResponseAsString { get; set; }
    }
}

