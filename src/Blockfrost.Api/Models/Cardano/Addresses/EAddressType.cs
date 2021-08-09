//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    public enum EAddressType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"byron")]
        Byron = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"shelley")]
        Shelley = 1,
    }
}