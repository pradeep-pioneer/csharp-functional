using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Cs.Functional.Basics
{
    static class Program
    {
        static void Main(string[] args)
        {
            // 1. Basics
            BasicsExample();

            // 2. Practical Usage
            PracticalUsageRetryCurried();
            PracticalUsageRetryFluent();
            PracticalUsageRetryCurriedCoolDown();
            PracticalUsageLogginWithRetryLogic();
        }

        static void BasicsExample()
        {
            Basics.FunctionAsInput();
            Basics.FunctionAsOutput();
            Basics.CombiningTheInputOutput();
        }

        static void PracticalUsageRetryCurriedCoolDown()
        {
            var result = PracticalUsage.ExecuteWithCoolDownRetryLogicCurried(5, CoolDown)(SomeTask);
            PrintExecutionResult(result);
        }

        static void PracticalUsageRetryCurried()
        {
            var result = PracticalUsage.ExecuteWithRetriesCurried(5)(SomeTask);
            PrintExecutionResult(result);
        }

        static void PracticalUsageRetryFluent()
        {
            Action action = SomeTask;
            var result = action.ExecuteWithRetriesFluent(5);
            PrintExecutionResult(result);
        }
        static void PracticalUsageLogginWithRetryLogic()
        {
            PracticalUsage.ExecuteWithLogging(Console.Out)
                (PracticalUsage.ExecuteWithRetriesCurried)
                (5)
                (SomeTask)
                .PrintExecutionResult();
        }

        static void SomeTask()
        {
            var result = DateTime.Now.Minute % 2 != 0;
            if (!result)
                throw new Exception("I like odd numbers!");
            Console.WriteLine("This is okay for me!");
        }

        public static void PrintExecutionResult(this ExecutionResult result)
        {
            if (result.HadErrors)
            {
                result.Exceptions.AsParallel().ForAll(ex => Console.WriteLine($"\n\nException: {ex.Message} - {ex.GetType()}"));
            }
            else
            {
                Console.WriteLine("No Errors!");
            }
        }

        static void CoolDown()
        {
            Thread.Sleep(2000);
        }
    }
}
