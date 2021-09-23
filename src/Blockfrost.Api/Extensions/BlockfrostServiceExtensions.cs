using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Blockfrost.Api.Http;
using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Polly;

namespace Blockfrost.Api.Extensions
{
    public static class BlockfrostServiceExtensions
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
            return services.AddBlockfrostService<Services.IAccountsService, Services.AccountsService>(projectName);
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
            return services.AddBlockfrostService<Services.IAccountsService, Services.AccountsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IAccountsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAccountsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.IAccountsService, Services.AccountsService>(projectName);
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
            return services.AddBlockfrostService<Services.IAccountsService, Services.AccountsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IAddressesService, Services.AddressesService>(projectName);
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
            return services.AddBlockfrostService<Services.IAddressesService, Services.AddressesService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IAddressesService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressesService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.IAddressesService, Services.AddressesService>(projectName);
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
            return services.AddBlockfrostService<Services.IAddressesService, Services.AddressesService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IAssetsService, Services.AssetsService>(projectName);
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
            return services.AddBlockfrostService<Services.IAssetsService, Services.AssetsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IAssetsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAssetsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.IAssetsService, Services.AssetsService>(projectName);
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
            return services.AddBlockfrostService<Services.IAssetsService, Services.AssetsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IBlocksService, Services.BlocksService>(projectName);
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
            return services.AddBlockfrostService<Services.IBlocksService, Services.BlocksService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IBlocksService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlocksService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.IBlocksService, Services.BlocksService>(projectName);
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
            return services.AddBlockfrostService<Services.IBlocksService, Services.BlocksService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IEpochsService, Services.EpochsService>(projectName);
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
            return services.AddBlockfrostService<Services.IEpochsService, Services.EpochsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IEpochsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddEpochsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.IEpochsService, Services.EpochsService>(projectName);
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
            return services.AddBlockfrostService<Services.IEpochsService, Services.EpochsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.ILedgerService, Services.LedgerService>(projectName);
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
            return services.AddBlockfrostService<Services.ILedgerService, Services.LedgerService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IMetadataService, Services.MetadataService>(projectName);
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
            return services.AddBlockfrostService<Services.IMetadataService, Services.MetadataService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.INetworkService, Services.NetworkService>(projectName);
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
            return services.AddBlockfrostService<Services.INetworkService, Services.NetworkService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IPoolsService, Services.PoolsService>(projectName);
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
            return services.AddBlockfrostService<Services.IPoolsService, Services.PoolsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="IPoolsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPoolsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.IPoolsService, Services.PoolsService>(projectName);
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
            return services.AddBlockfrostService<Services.IPoolsService, Services.PoolsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IScriptsService, Services.ScriptsService>(projectName);
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
            return services.AddBlockfrostService<Services.IScriptsService, Services.ScriptsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.ITransactionsService, Services.TransactionsService>(projectName);
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
            return services.AddBlockfrostService<Services.ITransactionsService, Services.TransactionsService>(projectName, connectionLimit);
        }
        /// <summary>
        /// Adds the <see cref="ITransactionsService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionsService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<Services.ITransactionsService, Services.TransactionsService>(projectName);
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
            return services.AddBlockfrostService<Services.ITransactionsService, Services.TransactionsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IHealthService, Services.HealthService>(projectName);
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
            return services.AddBlockfrostService<Services.IHealthService, Services.HealthService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IAddService, Services.AddService>(projectName);
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
            return services.AddBlockfrostService<Services.IAddService, Services.AddService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IGatewayService, Services.GatewayService>(projectName);
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
            return services.AddBlockfrostService<Services.IGatewayService, Services.GatewayService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IPinsService, Services.PinsService>(projectName);
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
            return services.AddBlockfrostService<Services.IPinsService, Services.PinsService>(projectName, connectionLimit);
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
            return services.AddBlockfrostService<Services.IMetricsService, Services.MetricsService>(projectName);
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
            return services.AddBlockfrostService<Services.IMetricsService, Services.MetricsService>(projectName, connectionLimit);
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
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
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
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey)
        {
            return _ = services.AddBlockfrost(network, apiKey, Constants.CONNECTION_LIMIT);
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <param name="connectionLimit">The number of connections the services will use.</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            string projectName = $"blockfrost-{network}-project";

            services.ConfigureBlockfrost(network, apiKey, projectName, connectionLimit);
            _ = services.AddCardanoServices(projectName);
            return services;
        }

        public static void ConfigureBlockfrost(this IServiceCollection services, string network, string apiKey, string projectName, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            if (connectionLimit > Constants.CONNECTION_LIMIT)
            {
                throw new ArgumentOutOfRangeException(nameof(connectionLimit), $"Connections are limited to {Constants.CONNECTION_LIMIT}");
            }

            services.TryAddSingleton(new BlockfrostProject()
            {
                ApiKey = apiKey,
                ConnectionLimit = $"{connectionLimit}",
                Name = projectName,
                Network = network
            });
            services.TryAddSingleton<BlockfrostAuthorizationHandler>();
            services.TryAddSingleton<RequestThrottler>();

            _ = services
                .AddOptions<BlockfrostOptions>()
                .Configure<BlockfrostProject>((projects, project) =>
                {
                    projects.Add(projectName, project);
                });
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            _ = services.ConfigureBlockfrost(projectName, configuration);
            _ = services.AddCardanoServices(projectName);
            //_ = services.AddIPFSServices(projectName);
            //_ = services.AddNutlinkServices(projectName);
            return services;
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
            where TClient : class
            where TImplementation : ABlockfrostService, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>($"{name}:{typeof(TImplementation).Name}", (client, provider) =>
            {
                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                var migration = typeof(TClient).GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("IServiceMigration", StringComparison.OrdinalIgnoreCase));
                var network = options.Value[name].Network;
                if (migration != null)
                {
                    var service = ServiceFactory<TImplementation>(
                        provider.GetService(migration.GenericTypeArguments.FirstOrDefault()),
                        client,
                        network,
                        connectionLimit);
                    return service;
                }
                else
                {
                    var types = new[] { typeof(Services.IHealthService), typeof(Services.IMetricsService), typeof(HttpClient) };
                    var ctor = typeof(TImplementation).GetConstructor(types);

                    if (ctor == null)
                    {
                        var service = ServiceFactory<TImplementation>(
                            client,
                            network,
                            connectionLimit);
                        return service;
                    }
                    else
                    {
                        ConfigureHttpClient(client, network, connectionLimit);
                        var health = CreateClient<Services.IHealthService, Services.HealthService>(network, client);
                        var metrics = CreateClient<Services.IMetricsService, Services.MetricsService>(network, client);
                        var blockfrostService = (TImplementation)Activator.CreateInstance(typeof(TImplementation), new object[] { health, metrics, client });
                        blockfrostService.Network = network;
                        return blockfrostService;
                    }
                }
            }).AddBlockfrostMessageHandlers();
        }

        public static TClient CreateClient<TClient, TImplementation>(string network, params object[] args)
            where TClient : class
            where TImplementation : ABlockfrostService
        {
            object service = Activator.CreateInstance(typeof(TImplementation), args);
            ((TImplementation)service).Network = network;
            return (TClient)service;
        }

        public static IHttpClientBuilder AddBlockfrostMessageHandlers(this IHttpClientBuilder builder, int retries = 3, int timeoutMilliseconds = 600)
        {
            return builder
                .ConfigurePrimaryHttpMessageHandler<RequestThrottler>()
                .SetHandlerLifetime(Timeout.InfiniteTimeSpan)
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(retries, _ => TimeSpan.FromMilliseconds(timeoutMilliseconds)));
            ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="projectName"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            if (!services.Any(s => s.ServiceType.FullName.Contains(typeof(IOptions<BlockfrostOptions>).Name)))
            {
                _ = services.Configure<BlockfrostOptions>(configuration.GetSection($"Blockfrost"));
                var project = configuration.GetSection($"Blockfrost:{projectName}").Get<BlockfrostProject>();
                if (project == null)
                {
                    throw new InvalidOperationException($"The specified project '{projectName}' is not configured in the 'Blockfrost' section of the appsettings");
                }

                if (string.IsNullOrEmpty(project.ApiKey))
                {
                    project.ApiKey = Environment.GetEnvironmentVariable(Constants.ENV_BFCLI_API_KEY);
                }

                if (string.IsNullOrEmpty(project.Network))
                {
                    project.Network = Environment.GetEnvironmentVariable(Constants.ENV_BFCLI_NETWORK);
                }

                services.TryAddSingleton(project);
            }

            services.TryAddSingleton<BlockfrostAuthorizationHandler>();
            services.TryAddSingleton<RequestThrottler>();
            return services;
        }

        /// <summary>
        /// Helper to configure the BaseAddress of the HttpClient used in the BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="network"></param>
        private static void ConfigureHttpClient(HttpClient client, string network, int sockets)
        {
            client.DefaultRequestHeaders.Add($"User-Agent", $"blockfrost-dotnet / v0.1.0 {network}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (sockets > Constants.CONNECTION_LIMIT)
            {
                sockets = Constants.CONNECTION_LIMIT;
            }

            client.BaseAddress = network switch
            {
                "testnet" => new Uri(Constants.API_URL_TESTNET),
                "mainnet" => new Uri(Constants.API_URL_MAINNET),
                "ipfs" => new Uri(Constants.API_URL_IPFS),
                _ => throw new NotSupportedException($"The specified network '{network}' is not supported"),
            };
            ServicePointManager.FindServicePoint(address: client.BaseAddress).ConnectionLimit = sockets;
        }

        /// <summary>
        /// Helper factory to configure the requested BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="client"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        private static TService ServiceFactory<TService>(HttpClient client, string network, int sockets = Constants.CONNECTION_LIMIT) where TService : ABlockfrostService
        {
            ConfigureHttpClient(client, network, sockets);
            var blockfrostService = (TService)Activator.CreateInstance(typeof(TService), new object[] { client });
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
        private static TService ServiceFactory<TService>(object migration, HttpClient client, string network, int sockets = Constants.CONNECTION_LIMIT) where TService : ABlockfrostService
        {
            ConfigureHttpClient(client, network, sockets);
            var blockfrostService = (TService)Activator.CreateInstance(typeof(TService), new object[] { migration, client });
            blockfrostService.Network = network;
            return blockfrostService;
        }
    }
}

