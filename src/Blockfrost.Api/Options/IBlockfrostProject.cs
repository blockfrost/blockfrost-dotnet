namespace Blockfrost.Api.Options
{
    public interface IBlockfrostProject
    {
        string ApiKey { get; set; }
        string Name { get; set; }
        string Network { get; set; }
        string ConnectionLimit { get; set; }
    }
}
