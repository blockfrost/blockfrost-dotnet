namespace Blockfrost.ConsoleTool.Commands
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