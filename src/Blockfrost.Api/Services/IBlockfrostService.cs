using System.Collections.Generic;using System.ComponentModel.DataAnnotations;using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface IBlockfrostService
    {
        string BaseUrl { get; set; }
        bool ReadResponseAsString { get; set; }
        Task<InfoResponse> GetInfoAsync();
        Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken);
        Task<ClockResponse> GetClockAsync();
        Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken);
        Task<GenesisContentResponse> GenesisAsync();
        Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken);
        Task<HealthResponse> GetHealthAsync();
        Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken);
        Task<NetworkResponse> NetworkAsync();
        Task<NetworkResponse> NetworkAsync(CancellationToken cancellationToken);
    }
}