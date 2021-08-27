// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
