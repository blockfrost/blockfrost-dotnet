namespace Blockfrost.Api
{
    public static class Constants
    {
        public const string API_URL = "https://blockfrost.io/";
        public const string API_VERSION = "0.8.5";

        public const string APPSETTINGS_TEST_FILENAME = "appsettings.test.json";
        public const string APPSETTINGS_FILENAME = "appsettings.json";

        // SUPPORTEF ENVIRONMENT VARIABLES
        public const string ENV_ENVIRONMENT = "NETCORE_ENVIRONMENT";
        public const string ENV_BF_RATE_LIMIT = "BF_RATE_LIMIT";
        public const string ENV_BFCLI_API_KEY = "BFCLI_API_KEY";
        public const string ENV_BFCLI_NETWORK = "BFCLI_NETWORK";

        // NETWORK NAMES
        public const string NETWORK_MAINNET = "mainnet";
        public const string NETWORK_IPFS = "ipfs";
        public const string NETWORK_TESTNET = "testnet";

        // DEFAULT PROJECT NAMES
        public const string PROJECT_NAME_IPFS = "Blockfrost.Net.Sdk-ipfs";
        public const string PROJECT_NAME_MAINNET = "Blockfrost.Net.Sdk-mainnet";
        public const string PROJECT_NAME_TESTNET = "Blockfrost.Net.Sdk-testnet";

        // LIMITS
        public const int CONNECTION_LIMIT = 10;
        public const int RATE_LIMIT = 10;
        public const int RATE_LIMIT_INTERVAL = 1000;

        public const int BURST_LIMIT = 500;
        public const int BURST_COOLDOWN = 10;
        public const int BURST_COOLDOWN_INTERVAL = 1000;

        public const string API_URL_TESTNET = "https://cardano-testnet.blockfrost.io/api/v0/";
        public const string API_URL_MAINNET = "https://cardano-mainnet.blockfrost.io/api/v0/";
        public const string API_URL_IPFS = "https://ipfs.blockfrost.io/api/v0/";

        // RETRIES
        public const int RETRIES = 3;
        public const int RETRY_TIMEOUT = 600;

        // TESTS
        public const string TEST_VECTOR_ROOT_DIRNAME = "dat";

        public const string PROTOCOL_PARAMETERS_FILENAME = "protocol.json";
    }
}
