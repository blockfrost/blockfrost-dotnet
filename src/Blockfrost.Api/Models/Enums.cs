namespace Blockfrost.Api
{
    public enum ESortOrder
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,
    }

    public enum EContentType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"application/cbor")]
        ApplicationCbor = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"application/json")]
        ApplicationJson = 1,
    }
}
