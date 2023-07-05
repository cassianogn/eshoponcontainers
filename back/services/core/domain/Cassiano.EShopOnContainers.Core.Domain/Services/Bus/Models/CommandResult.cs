using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System.Collections.Generic;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models
{
    public class CommandResult<TResult> : CommandResult
    {
        protected CommandResult(bool proccessCompleted, TResult? result, IReadOnlyCollection<string>? businessRuleErrors, Exception? exception): base(proccessCompleted, businessRuleErrors, exception)
        {
            Result = result;
        }

        public TResult? Result { get; private set; }
        public static CommandResult<TResult?> CommandFinished(TResult? result) => new(true, result, null, null);

    }
    public class CommandResult
    {
        protected CommandResult(bool proccessCompleted, IReadOnlyCollection<string>? businessRuleErrors, Exception? exception)
        {
            ProccessCompleted = proccessCompleted;
            Exception = exception;
        }

        public bool ProccessCompleted { get; private set; }
        public Exception? Exception { get; private set; }

        public static CommandResult CommandFinished() => new (true, null, null);
        public static CommandResult GetExceptionError(Exception exception) => new (false, null, exception);

    }
}
