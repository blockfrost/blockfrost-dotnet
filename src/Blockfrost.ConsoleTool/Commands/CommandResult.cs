using System;

namespace Blockfrost.ConsoleTool.Commands
{
    public class CommandResult
    {
        public CommandOutcome Outcome { get; }

        public string Result { get; }

        public Exception Exception { get; }

        public CommandResult(CommandOutcome outcome, string result, Exception exception = null)
        {
            Outcome = outcome;
            Result = result;
            Exception = exception;

        }

        public static CommandResult Success(string result) =>
            new(CommandOutcome.Success, result);

        public static CommandResult FailureInvalidOptions(string result) =>
            new(CommandOutcome.FailureInvalidOptions, result);

        public static CommandResult FailureTimedOut(string result) =>
            new(CommandOutcome.FailureTimedOut, result);

        public static CommandResult FailureCancelled(string result) =>
            new(CommandOutcome.FailureCancelled, result);

        public static CommandResult FailureUnhandledException(string result, Exception ex) =>
            new(CommandOutcome.FailureUnhandledException, result, ex);
    }
}