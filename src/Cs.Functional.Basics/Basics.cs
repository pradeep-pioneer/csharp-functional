using System;
using System.Linq;
namespace Cs.Functional.Basics
{
    public static class Basics
    {
        //Function as input
        public static void FunctionAsInput()
        {
            var stars = PrintDescriptionAndGetBottomStars("Passing Functions as Inputs to Other Functions");

            FunctionInputsDo();

            Console.WriteLine(stars);
        }

        private static void FunctionInputsDo()
        {
            var numbers = new int[] { 2, 4, 5, 9, 8 };
            //1. Old Fashioned Imperative Way
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            Console.WriteLine($"Sum using imperative style: {sum}");

            //2. using an external function
            sum = numbers.Aggregate(Add);
            Console.WriteLine($"Sum using external function: {sum}");

            //3. using a local function
            int add(int first, int second) => first + second;
            sum = numbers.Aggregate(add);
            Console.WriteLine($"Sum using local function: {sum}");

            //4. using a lambda
            sum = numbers.Aggregate((first, second) => first + second);
            Console.WriteLine($"Sum using lambda function: {sum}");
        }

        public static void FunctionAsOutput()
        {
            var stars = PrintDescriptionAndGetBottomStars("Functions as outputs");
            FunctionOutputsDo();
            Console.WriteLine(stars);
        }

        private static void FunctionOutputsDo()
        {
            var numbers = new int[] { 2, 4, 5, 9, 8 };

            var sumResult = GetOperation('+')(numbers);
            var subResult = GetOperation('-')(numbers);
            var mulResult = GetOperation('*')(numbers);
            var divResult = GetOperation('/')(numbers);

            Console.WriteLine($"Sum: {sumResult}");
            Console.WriteLine($"Substraction: {subResult}");
            Console.WriteLine($"Multiplication: {mulResult}");
            Console.WriteLine($"Division: {divResult}");
        }

        public static void CombiningTheInputOutput()
        {
            var stars = PrintDescriptionAndGetBottomStars("Passing function as input and getting function as output");
            CombiningInputOutputDo();
            Console.WriteLine(stars);
        }

        private static void CombiningInputOutputDo()
        {
            var numbers = new int[] { 2, 4, 5, 9, 8 };

            PerformOperatioAndPrintResult('+', GetOperation, numbers);
            PerformOperatioAndPrintResult('-', GetOperation, numbers);
            PerformOperatioAndPrintResult('*', GetOperation, numbers);
            PerformOperatioAndPrintResult('/', GetOperation, numbers);
        }

        private static void PerformOperatioAndPrintResult(char op, Func<char, Func<int[], int>> operation, params int[] input)
        {
            var inputString = string.Join(op, input);
            var result = operation(op)(input);
            Console.WriteLine($"{inputString} = {result}");
        }

        private static Func<int[], int> GetOperation(char operation)
        {
            switch (operation)
            {
                case '+':
                case 'a':
                case 'A':
                    return (int[] input) => input.Aggregate((first, second) => first + second);
                case '-':
                case 's':
                case 'S':
                    return (int[] input)
                        => input.OrderBy(num => num)
                                .Reverse()
                                .Aggregate((first, second) => first - second);
                case '*':
                case 'X':
                case 'x':
                case 'm':
                case 'M':
                    return (int[] input) => input.Aggregate((first, second) => first * second);
                case '/':
                case 'd':
                case 'D':
                    return (int[] input)
                        => input.OrderBy(num => num)
                                .Reverse()
                                .Aggregate((first, second) => first / second);
                default:
                    return null;
            }
        }

        public static void WrapperPattern()
        {
            var stars = PrintDescriptionAndGetBottomStars("Wrapper Pattern");
            Console.WriteLine(stars);
            WrapWithDecoration(FunctionInputsDo, "Passing Functions as Inputs to Other Functions", PrintDescriptionAndGetBottomStars);
            WrapWithDecoration(FunctionInputsDo, "Functions as outputs", PrintDescriptionAndGetBottomStars);
            Console.WriteLine(stars);
        }

        private static int Add(int first, int second) => first + second;

        private static void WrapWithDecoration(Action action, string description, Func<string, char, int, string> decorator)
        {
            var decorative = decorator(description, '*', 54);
            action();
            Console.Write(decorative);
        }

        private static string PrintDescriptionAndGetBottomStars(string description, char decorator = '*', int minLength = 54)
        {
            var starsNeeded = minLength - 2 - description.Length;
            var decorated = $" {description} ".PadLeft(minLength - (starsNeeded / 2), decorator).PadRight(minLength, decorator);
            var stars = "".PadLeft(minLength, decorator);
            Console.WriteLine($"{decorated}\n{stars}");
            return stars;
        }
    }
}
