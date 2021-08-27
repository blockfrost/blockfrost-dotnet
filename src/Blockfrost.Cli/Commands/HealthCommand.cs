// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public class HealthCommand : BlockfrostCommandBase
    {
        private readonly JsonSerializerOptions _options;

        public HealthCommand(IBlockfrostService service, JsonSerializerOptions options) : base(service)
        {
            _options = options;
        }

        protected string SerializeAsJson<T>(T result)
        {
            return JsonSerializer.Serialize(result, _options);
        }

        protected ValueTask<CommandResult> Success<T>(T result)
        {
            return ValueTask.FromResult(SuccessFromJson(result));
        }

        private CommandResult SuccessFromJson<T>(T result)
        {
            return CommandResult.Success(SerializeAsJson(result));
        }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                var response = await Service.GetHealthAsync(ct);
                return await Success(response);
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
