namespace Blockfrost.Api.Utils
{
    public interface ICardanoCliTransaction
    {
        string CBORHex { get; set; }
        string Description { get; set; }
        string Type { get; set; }
    }
}
