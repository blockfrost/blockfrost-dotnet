namespace Blockfrost.Api
{
    public interface IServiceMigration<TNewService> : IBlockfrostService where TNewService : IBlockfrostService
    {
        public TNewService V1 { get; set; }
    }
}
