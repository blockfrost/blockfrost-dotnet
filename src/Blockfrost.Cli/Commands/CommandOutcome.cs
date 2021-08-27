// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

namespace Blockfrost.Cli.Commands
{
    public enum CommandOutcome
    {
        Success = 0,
        FailureInvalidOptions,
        FailureTimedOut,
        FailureCancelled,
        FailureUnhandledException,
    }
}
