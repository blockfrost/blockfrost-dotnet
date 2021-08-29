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
