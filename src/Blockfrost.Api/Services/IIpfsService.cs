namespace Blockfrost.Api.Services
{
    public partial interface IIPFSService : IBlockfrostService
    {
        IHealthService Health { get; }
        IMetricsService Metrics { get; }

        IPinsService Pins { get; }
        IAddService Add { get; }
        IGatewayService Gateway { get; }
    }
}
