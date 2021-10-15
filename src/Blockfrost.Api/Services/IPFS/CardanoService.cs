using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Models;
using Blockfrost.Api.Services;

namespace Blockfrost.Api.Services.IPFS
{
    public partial class IPFSService : IIPFSService
    {
        public IPFSService(
            IHealthService health,
            IMetricsService metrics,
            IAddService add,
            IPinsService pins,
            IGatewayService gateway)
        {
            Health = health;
            Metrics = metrics;
            Add = add;
            Pins = pins;
            Gateway = gateway;
        }

        public IHealthService Health { get; }
        public IMetricsService Metrics { get; }

        public string Network { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public bool ReadResponseAsString { get; set; }

        public IPinsService Pins { get; }

        public IAddService Add { get; }

        public IGatewayService Gateway { get; }
    }
}
