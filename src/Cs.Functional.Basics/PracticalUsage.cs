using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Cs.Functional.Basics
{
    public class ExecutionResult
    {
        public bool HadErrors { get => Exceptions.Count() > 0; }
        public IEnumerable<Exception> Exceptions { get; set; }
    }

    public class ExecutionResult<T> : ExecutionResult
    {
        public T Result { get; set; }
    }

    public static class PracticalUsage
    {
        public static ExecutionResult ExecuteWithRetriesBasic(Action action, int retries, Action coolDownLogic = null)
        {
            bool error = true;
            int executionCount = 0;
            var exceptions = new List<Exception>();
            // why is this function not recursive?
            // isn't using loops against the spirit of functional programming?
            while (error && executionCount < retries)
            {
                try
                {
                    action();
                    executionCount++;
                    error = false;
                }
                catch (Exception ex)
                {
                    error = true;
                    executionCount++;
                    exceptions.Add(ex);
                    coolDownLogic?.Invoke();
                }
            }
            return new ExecutionResult() { Exceptions = exceptions };
        }

        public static Func<Action, ExecutionResult> ExecuteWithRetriesCurried(int retries)
        {
            return (action) => ExecuteWithRetriesBasic(action, retries);
        }

        public static ExecutionResult ExecuteWithRetriesFluent(this Action action, int retries)
        {
            return ExecuteWithRetriesBasic(action, retries);
        }

        // More advanced
        public static Func<Action, ExecutionResult> ExecuteWithCoolDownRetryLogicCurried(int retries, Action coolDownLogic)
        {
            return (action) => ExecuteWithRetriesBasic(action, retries, coolDownLogic);
        }

        public static ExecutionResult ExecuteWithCoolDownRetryLogicExtension(this Action action, int retries, Action coolDownLogic)
        {
            return ExecuteWithRetriesBasic(action, retries, coolDownLogic);
        }

        public static Func<Func<int, Func<Action, ExecutionResult>>, Func<int, Func<Action, ExecutionResult>>> ExecuteWithLogging(TextWriter logger, string message = "")
        {
            Func<Func<int, Func<Action, ExecutionResult>>, Func<int, Func<Action, ExecutionResult>>> logExecutor = (action) =>
            {
                logger.WriteLine($"Executing: {nameof(action)}");
                return action;
            };
            return logExecutor;
        }
    }
}
