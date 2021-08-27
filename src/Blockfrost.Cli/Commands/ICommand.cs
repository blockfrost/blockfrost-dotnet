// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public interface ICommand
    {
        ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}
