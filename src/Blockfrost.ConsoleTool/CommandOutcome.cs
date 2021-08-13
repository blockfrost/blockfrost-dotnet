namespace Blockfrost.ConsoleTool
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