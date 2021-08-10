﻿using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.ConsoleTool
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
                HealthResponse response = await Service.GetHealthAsync(ct);
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