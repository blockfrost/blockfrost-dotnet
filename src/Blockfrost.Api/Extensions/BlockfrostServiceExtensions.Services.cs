using System;
using System.Linq;
using System.Net.Http;
using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;

namespace Blockfrost.Api.Extensions
{
    public static partial class BlockfrostServiceExtensions
    {
        #region AccountsService
        /// <summary>
        /// Adds the <see cref="IAccountService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IAccountService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IAccountsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAccountService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IAccountService, AccountService>(projectName);
            return services.AddBlockfrostService<Api.Services.IAccountsService, Api.Services.AccountsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAccountService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IAccountService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IAccountsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAccountService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IAccountService, AccountService>(projectName);
            return services.AddBlockfrostService<Api.Services.IAccountsService, Api.Services.AccountsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IAccountsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAccountsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IAccountsService, Api.Services.AccountsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAccountsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAccountsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IAccountsService, Api.Services.AccountsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IAccountService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddAccountService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddAccountService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="IAccountsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddAccountsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddAccountsService(projectName);
            return services;
        }
        #endregion AccountsService
        #region AddressesService
        /// <summary>
        /// Adds the <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IAddressService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IAddressesService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IAddressService, AddressService>(projectName);
            return services.AddBlockfrostService<Api.Services.IAddressesService, Api.Services.AddressesService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IAddressService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IAddressesService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IAddressService, AddressService>(projectName);
            return services.AddBlockfrostService<Api.Services.IAddressesService, Api.Services.AddressesService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IAddressesService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressesService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IAddressesService, Api.Services.AddressesService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAddressesService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressesService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IAddressesService, Api.Services.AddressesService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IAddressService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddAddressService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddAddressService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="IAddressesService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddAddressesService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddAddressesService(projectName);
            return services;
        }
        #endregion AddressesService
        #region AssetsService
        /// <summary>
        /// Adds the <see cref="IAssetService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IAssetService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IAssetsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAssetService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IAssetService, AssetService>(projectName);
            return services.AddBlockfrostService<Api.Services.IAssetsService, Api.Services.AssetsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAssetService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IAssetService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IAssetsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAssetService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IAssetService, AssetService>(projectName);
            return services.AddBlockfrostService<Api.Services.IAssetsService, Api.Services.AssetsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IAssetsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAssetsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IAssetsService, Api.Services.AssetsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAssetsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAssetsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IAssetsService, Api.Services.AssetsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IAssetService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddAssetService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddAssetService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="IAssetsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddAssetsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddAssetsService(projectName);
            return services;
        }
        #endregion AssetsService
        #region BlocksService
        /// <summary>
        /// Adds the <see cref="IBlockService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IBlockService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IBlocksService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IBlockService, BlockService>(projectName);
            return services.AddBlockfrostService<Api.Services.IBlocksService, Api.Services.BlocksService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IBlockService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IBlockService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IBlocksService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IBlockService, BlockService>(projectName);
            return services.AddBlockfrostService<Api.Services.IBlocksService, Api.Services.BlocksService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IBlocksService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlocksService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IBlocksService, Api.Services.BlocksService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IBlocksService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlocksService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IBlocksService, Api.Services.BlocksService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IBlockService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddBlockService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddBlockService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="IBlocksService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddBlocksService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddBlocksService(projectName);
            return services;
        }
        #endregion BlocksService
        #region EpochsService
        /// <summary>
        /// Adds the <see cref="IEpochService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IEpochService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IEpochsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddEpochService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IEpochService, EpochService>(projectName);
            return services.AddBlockfrostService<Api.Services.IEpochsService, Api.Services.EpochsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IEpochService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IEpochService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IEpochsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddEpochService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IEpochService, EpochService>(projectName);
            return services.AddBlockfrostService<Api.Services.IEpochsService, Api.Services.EpochsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IEpochsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddEpochsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IEpochsService, Api.Services.EpochsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IEpochsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddEpochsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IEpochsService, Api.Services.EpochsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IEpochService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddEpochService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddEpochService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="IEpochsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddEpochsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddEpochsService(projectName);
            return services;
        }
        #endregion EpochsService
        #region LedgerService
        /// <summary>
        /// Adds the <see cref="ILedgerService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;ILedgerService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;ILedgerService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddLedgerService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<ILedgerService, LedgerService>(projectName);
            return services.AddBlockfrostService<Api.Services.ILedgerService, Api.Services.LedgerService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="ILedgerService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;ILedgerService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;ILedgerService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddLedgerService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<ILedgerService, LedgerService>(projectName);
            return services.AddBlockfrostService<Api.Services.ILedgerService, Api.Services.LedgerService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="ILedgerService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddLedgerService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddLedgerService(projectName);
        }
        #endregion LedgerService
        #region MetadataService
        /// <summary>
        /// Adds the <see cref="IMetadataService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IMetadataService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IMetadataService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddMetadataService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IMetadataService, MetadataService>(projectName);
            return services.AddBlockfrostService<Api.Services.IMetadataService, Api.Services.MetadataService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IMetadataService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IMetadataService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IMetadataService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddMetadataService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IMetadataService, MetadataService>(projectName);
            return services.AddBlockfrostService<Api.Services.IMetadataService, Api.Services.MetadataService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IMetadataService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddMetadataService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddMetadataService(projectName);
        }
        #endregion MetadataService
        #region NetworkService
        /// <summary>
        /// Adds the <see cref="INetworkService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;INetworkService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;INetworkService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddNetworkService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<INetworkService, NetworkService>(projectName);
            return services.AddBlockfrostService<Api.Services.INetworkService, Api.Services.NetworkService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="INetworkService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;INetworkService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;INetworkService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddNetworkService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<INetworkService, NetworkService>(projectName);
            return services.AddBlockfrostService<Api.Services.INetworkService, Api.Services.NetworkService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="INetworkService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddNetworkService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddNetworkService(projectName);
        }
        #endregion NetworkService
        #region PoolsService
        /// <summary>
        /// Adds the <see cref="IPoolService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IPoolService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IPoolsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPoolService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<IPoolService, PoolService>(projectName);
            return services.AddBlockfrostService<Api.Services.IPoolsService, Api.Services.PoolsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IPoolService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;IPoolService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;IPoolsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPoolService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<IPoolService, PoolService>(projectName);
            return services.AddBlockfrostService<Api.Services.IPoolsService, Api.Services.PoolsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IPoolsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPoolsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IPoolsService, Api.Services.PoolsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IPoolsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPoolsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IPoolsService, Api.Services.PoolsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IPoolService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddPoolService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddPoolService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="IPoolsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddPoolsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddPoolsService(projectName);
            return services;
        }
        #endregion PoolsService
        #region ScriptsService
        /// <summary>
        /// Adds the <see cref="IScriptsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddScriptsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IScriptsService, Api.Services.ScriptsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IScriptsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddScriptsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IScriptsService, Api.Services.ScriptsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IScriptsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddScriptsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddScriptsService(projectName);
        }
        #endregion ScriptsService
        #region TransactionsService
        /// <summary>
        /// Adds the <see cref="ITransactionService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;ITransactionService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;ITransactionsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionService(this IServiceCollection services, string projectName)
        {
            _ = services.AddBlockfrostService<ITransactionService, TransactionService>(projectName);
            return services.AddBlockfrostService<Api.Services.ITransactionsService, Api.Services.TransactionsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="ITransactionService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// A newer version of the service is available through
        /// <code>
        /// var newService = _services.GetRequiredService&lt;ITransactionService&gt;().V1;
        /// // or
        /// var newService = _services.GetRequiredService&lt;ITransactionsService&gt;();
        ///</code>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            _ = services.AddBlockfrostService<ITransactionService, TransactionService>(projectName);
            return services.AddBlockfrostService<Api.Services.ITransactionsService, Api.Services.TransactionsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="ITransactionsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.ITransactionsService, Api.Services.TransactionsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="ITransactionsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.ITransactionsService, Api.Services.TransactionsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="ITransactionService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddTransactionService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddTransactionService(projectName);
        }
        /// <summary>
        /// Adds the <see cref="ITransactionsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddTransactionsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            _ = services.AddTransactionsService(projectName);
            return services;
        }
        #endregion TransactionsService
        #region HealthService
        /// <summary>
        /// Adds the <see cref="IHealthService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddHealthService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IHealthService, Api.Services.HealthService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IHealthService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddHealthService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IHealthService, Api.Services.HealthService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IHealthService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddHealthService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddHealthService(projectName);
        }
        #endregion HealthService
        #region AddService
        /// <summary>
        /// Adds the <see cref="IAddService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IAddService, Api.Services.AddService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IAddService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IAddService, Api.Services.AddService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IAddService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddAddService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddAddService(projectName);
        }
        #endregion AddService
        #region GatewayService
        /// <summary>
        /// Adds the <see cref="IGatewayService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddGatewayService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IGatewayService, Api.Services.GatewayService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IGatewayService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddGatewayService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IGatewayService, Api.Services.GatewayService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IGatewayService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddGatewayService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddGatewayService(projectName);
        }
        #endregion GatewayService
        #region PinsService
        /// <summary>
        /// Adds the <see cref="IPinsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPinsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IPinsService, Api.Services.PinsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IPinsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPinsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IPinsService, Api.Services.PinsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IPinsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddPinsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddPinsService(projectName);
        }
        #endregion PinsService
        #region MetricsService
        /// <summary>
        /// Adds the <see cref="IMetricsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddMetricsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Api.Services.IMetricsService, Api.Services.MetricsService>(projectName);
        }

        /// <summary>
        /// Adds the <see cref="IMetricsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddMetricsService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<Api.Services.IMetricsService, Api.Services.MetricsService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the <see cref="IMetricsService"/> and related services to the the service collection using the provided configuration
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        public static IHttpClientBuilder AddMetricsService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            _ = services.ConfigureBlockfrost(projectName, config);
            return services.AddMetricsService(projectName);
        }
        #endregion MetricsService

        #region CardanoServices
        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <returns></returns>
        public static IServiceCollection AddCardanoServices(this IServiceCollection services, string projectName)
        {
            //services.TryAddSingleton(provider =>
            //{
            //    var options = provider.GetService<IOptions<BlockfrostOptions>>();
            //    return new BlockfrostAuthorizationHandler(options.Value[projectName].ApiKey);
            //});
            _ = services.AddHealthService(projectName);
            _ = services.AddMetricsService(projectName);

            _ = services.AddAccountService(projectName);
            _ = services.AddAddressService(projectName);
            _ = services.AddAssetService(projectName);
            _ = services.AddBlockService(projectName);
            _ = services.AddEpochService(projectName);
            _ = services.AddLedgerService(projectName);
            _ = services.AddMetadataService(projectName);
            _ = services.AddNetworkService(projectName);
            _ = services.AddPoolService(projectName);
            _ = services.AddScriptsService(projectName);
            _ = services.AddTransactionService(projectName);
            _ = services.AddRootService(projectName);

            _ = services.AddBlockfrostService<Services.ICardanoService, CardanoService>(projectName);
            return services;
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddCardanoServices(this IServiceCollection services, string network, string apiKey, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            string projectName = $"Anonymous.Blockfrost.{network}.Project";

            services.ConfigureBlockfrost(network, apiKey, projectName, connectionLimit);

            _ = services.AddBasicBlockfrostService(projectName, connectionLimit);
            _ = services.AddHealthService(projectName, connectionLimit);
            _ = services.AddMetricsService(projectName, connectionLimit);

            _ = services.AddAccountService(projectName, connectionLimit);
            _ = services.AddAddressService(projectName, connectionLimit);
            _ = services.AddAssetService(projectName, connectionLimit);
            _ = services.AddBlockService(projectName, connectionLimit);
            _ = services.AddEpochService(projectName, connectionLimit);
            _ = services.AddLedgerService(projectName, connectionLimit);
            _ = services.AddMetadataService(projectName, connectionLimit);
            _ = services.AddNetworkService(projectName, connectionLimit);
            _ = services.AddPoolService(projectName, connectionLimit);
            _ = services.AddScriptsService(projectName, connectionLimit);
            _ = services.AddTransactionService(projectName, connectionLimit);

            _ = services.AddBlockfrostService<Services.ICardanoService, CardanoService>(projectName);
            return services;
        }
        #endregion CardanoServices

        /// <summary>
        /// Adds a new <see cref="IBlockfrostService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddRootService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IBlockfrostService, RootService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IBlockfrostService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBasicBlockfrostService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<IBlockfrostService, RootService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds a new <see cref="IBlockfrostService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockfrostService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<IBlockfrostService, RootService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds the IHttpClientFactory and related services to the IServiceCollection and configures a binding between the TClient type and a named HttpClient.
        /// </summary>
        /// <typeparam name="TClient">The type of the typed blockfrost service. They type specified will be registered in the service collection as a transient service. See ITypedHttpClientFactory<TClient> for more details about authoring typed clients.</typeparam>
        /// <typeparam name="TImplementation">The implementation type of the typed blockfrost service. They type specified will be instantiated by the ITypedHttpClientFactory<TClient>.</typeparam>
        /// <param name="services">The IServiceCollection.</param>
        /// <param name="name">The logical name of the HttpClient to configure.</param>
        /// <param name="configureClient">A delegate that is used to configure an HttpClient.</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockfrostService<TClient, TImplementation>(this IServiceCollection services, string name, Action<IServiceProvider, HttpClient> configureClient)
            where TClient : class
            where TImplementation : class, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>($"{name}:{typeof(TImplementation).Name}", configureClient)
                .AddBlockfrostMessageHandlers();
        }

        /// <summary>
        /// Adds the IHttpClientFactory and related services to the IServiceCollection and configures a binding between the TClient type and a named HttpClient.
        /// </summary>
        /// <typeparam name="TClient">The type of the typed blockfrost service. They type specified will be registered in the service collection as a transient service. See ITypedHttpClientFactory<TClient> for more details about authoring typed clients.</typeparam>
        /// <typeparam name="TImplementation">The implementation type of the typed blockfrost service. They type specified will be instantiated by the ITypedHttpClientFactory<TClient>.</typeparam>
        /// <param name="services">The IServiceCollection.</param>
        /// <param name="name">The logical name of the HttpClient to configure.</param>
        public static IHttpClientBuilder AddBlockfrostService<TClient, TImplementation>(this IServiceCollection services, string name, int connectionLimit = Constants.CONNECTION_LIMIT)
            where TClient : class, IBlockfrostService
            where TImplementation : class, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>($"{name}:{typeof(TImplementation).Name}", (client, provider) =>
            {
                TImplementation service = default;

                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                var migration = typeof(TClient).GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("IServiceMigration", StringComparison.OrdinalIgnoreCase));
                string network = options.Value[name].Network;

                if (migration != null)
                {
                    service = ServiceFactory<TImplementation>(
                        provider.GetService(migration.GenericTypeArguments.FirstOrDefault()),
                        client,
                        name,
                        network,
                        connectionLimit);
                }
                else
                {
                    if (typeof(TClient) == typeof(Services.ICardanoService))
                    {
                        ConfigureHttpClient(client, network, connectionLimit);
                        var health = CreateClient<Api.Services.IHealthService, Api.Services.HealthService>(name, network, client);
                        var metrics = CreateClient<Api.Services.IMetricsService, Api.Services.MetricsService>(name, network, client);
                        service = (TImplementation)Activator.CreateInstance(typeof(TImplementation), new object[] { 
                            health,
                            metrics,
                            CreateClient<Api.Services.IAccountsService, Api.Services.AccountsService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.IAddressesService, Api.Services.AddressesService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.IAssetsService, Api.Services.AssetsService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.IBlocksService, Api.Services.BlocksService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.IEpochsService, Api.Services.EpochsService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.ILedgerService, Api.Services.LedgerService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.IMetadataService, Api.Services.MetadataService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.IPoolsService, Api.Services.PoolsService>(name, network, health, metrics, client),
                            CreateClient<Api.Services.ITransactionsService, Api.Services.TransactionsService>(name, network, health, metrics, client)
                        });

                    }
                    else
                    {
                        var types = new[] { typeof(Api.Services.IHealthService), typeof(Api.Services.IMetricsService), typeof(HttpClient) };
                        var ctor = typeof(TImplementation).GetConstructor(types);

                        if (ctor == null)
                        {
                            service = ServiceFactory<TImplementation>(
                                client,
                                name,
                                network,
                                connectionLimit);
                        }
                        else
                        {
                            ConfigureHttpClient(client, network, connectionLimit);
                            service = (TImplementation)Activator.CreateInstance(typeof(TImplementation), new object[] {
                                        CreateClient<Api.Services.IHealthService, Api.Services.HealthService>(name, network, client),
                                        CreateClient<Api.Services.IMetricsService, Api.Services.MetricsService>(name, network, client),
                                        client });
                        }
                    }
                }
                service.Name = name;
                service.Network = network;
                return service;
            }).AddBlockfrostMessageHandlers();
        }

        public static TClient CreateClient<TClient, TImplementation>(string name, string network, params object[] args)
            where TClient : class
            where TImplementation : class, IBlockfrostService
        {
            object service = Activator.CreateInstance(typeof(TImplementation), args);
            ((TImplementation)service).Name = name;
            ((TImplementation)service).Network = network;
            return (TClient)service;
        }

        public static IHttpClientBuilder AddBlockfrostMessageHandlers(this IHttpClientBuilder builder, int retries = 3, int timeoutMilliseconds = 600)
        {
            return builder
                .ConfigurePrimaryHttpMessageHandler<Http.RequestThrottler>()
                .SetHandlerLifetime(System.Threading.Timeout.InfiniteTimeSpan)
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(retries, _ => TimeSpan.FromMilliseconds(timeoutMilliseconds)));
            ;
        }

        /// <summary>
        /// Helper factory to configure the requested BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="client"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        private static TService ServiceFactory<TService>(HttpClient client, string name, string network, int sockets = Constants.CONNECTION_LIMIT)
            where TService : class, IBlockfrostService
        {
            ConfigureHttpClient(client, network, sockets);
            var blockfrostService = (TService)Activator.CreateInstance(typeof(TService), new object[] { client });
            blockfrostService.Name = name;
            blockfrostService.Network = network;
            return blockfrostService;
        }

        /// <summary>
        /// Helper factory to configure the requested BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="client"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        private static TService ServiceFactory<TService>(object migration, HttpClient client, string name, string network, int sockets = Constants.CONNECTION_LIMIT) where TService : class, IBlockfrostService
        {
            ConfigureHttpClient(client, network, sockets);
            var blockfrostService = (TService)Activator.CreateInstance(typeof(TService), new object[] { migration, client });
            blockfrostService.Name = network;
            blockfrostService.Network = network;
            return blockfrostService;
        }
    }
}
