namespace ConsoleApp1
{
    internal class Program
    {
        enum ArithmeticOperation
        {
            Addition = '+',
            Subtraction = '-',
            Multiplication = '*',
            Division = '/'
        }
        static float DoArithmetic(ArithmeticOperation operation, float firstNum, float secondNum)
        {
            switch (operation)
            {
                case ArithmeticOperation.Addition:
                    return firstNum + secondNum;
                case ArithmeticOperation.Subtraction:
                    return firstNum - secondNum;
                case ArithmeticOperation.Multiplication:
                    return firstNum * secondNum;
                case ArithmeticOperation.Division:
                    return firstNum / secondNum;
                default:
                    return 0;
                    break;
            }
        }
        
        private static void Main(string[] args)
        {
            Console.WriteLine("Please choose one of the operations +, -, *, /");
            
            char operationSymbol = Console.ReadKey().KeyChar;

            if (!Enum.IsDefined(typeof(ArithmeticOperation), (int)operationSymbol))
            {
                Console.WriteLine("Error: Incorrect operation.");
                return;
            }
            
            Console.WriteLine("\nPlease input the first number");
            string sFirstNum = Console.ReadLine();
            float firstNum = float.Parse(sFirstNum);
            
            Console.WriteLine("Please input the second number");
            string sSecondNum = Console.ReadLine();
            float secondNum = float.Parse(sSecondNum);

            float res = DoArithmetic((ArithmeticOperation)operationSymbol, firstNum, secondNum);
            Console.WriteLine($"The result of the operation {operationSymbol} is {res}");
        }
    }
}