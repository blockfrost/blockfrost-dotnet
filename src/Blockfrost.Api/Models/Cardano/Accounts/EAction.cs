//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public enum EAction
    {
        [System.Runtime.Serialization.EnumMember(Value = @"registered")]
        Registered = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"deregistered")]
        Deregistered = 1,
    }
}
