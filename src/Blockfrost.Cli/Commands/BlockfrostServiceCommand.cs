using System.Text.Json;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public abstract class BlockfrostServiceCommand<TService> : CommandBase where TService : IBlockfrostService
    {
        //protected BlockfrostServiceCommand(TService service, JsonSerializerOptions options) : base(options)
        //{
        //    Service = service;
        //}

        public TService Service { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Count { get; set; } = 100;
        public int Page { get; set; } = 1;
        public ESortOrder Order { get; set; } = ESortOrder.Asc;

        protected string SerializeAsJson<T>(T result)
        {
            return JsonSerializer.Serialize(result, Options);
        }

        protected ValueTask<CommandResult> Success<T>(T result)
        {
            return ValueTask.FromResult(SuccessFromJson(result));
        }

        private CommandResult SuccessFromJson<T>(T result)
        {
            return CommandResult.Success(SerializeAsJson(result));
        }
    }
}
