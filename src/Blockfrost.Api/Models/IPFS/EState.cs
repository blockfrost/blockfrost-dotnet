﻿namespace Blockfrost.Api
{
    public enum EState
    {
        [System.Runtime.Serialization.EnumMember(Value = @"queued|pinned|unpinned|failed|gc")]
        Queued_pinned_unpinned_failed_gc = 0,
    }
}
