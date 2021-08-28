// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public abstract class BlockfrostCommandBase : ICommand
    {
        protected BlockfrostCommandBase(IBlockfrostService service)
        {
            Service = service;
        }

        protected IBlockfrostService Service { get; }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}
