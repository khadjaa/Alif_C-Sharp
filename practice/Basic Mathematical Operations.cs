//Your task is to create a function that does four basic mathematical operations.

using System;

namespace Solution
{
    public static class Program
    {
        public static double basicOp(char operation, double value1, double value2)
        {
            switch (operation)
            {
                case '+':
                    return value1 + value2;
                case '-':
                    return value1 - value2;
                case '*':
                    return value1 * value2;
                case '/':
                    if (value2 != 0)
                    {
                        return value1 / value2;
                    }
                    else
                    {
                        throw new ArgumentException("Cannot divide by zero.");
                    }
                default:
                    throw new ArgumentException("Unsupported operation.");
            }
        }
    }
}
