// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Blockfrost.Cli.Commands
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
