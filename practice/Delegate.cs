namespace ConsoleApp1._8kyu;

using System;

public delegate int MathOperation(int a, int b);

class Program
{
    static int Add(int a, int b)
    {
        return a + b;
    }

    static int Subtract(int a, int b)
    {
        return a - b;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static void Main()
    {
        MathOperation addDelegate = Add;
        MathOperation subtractDelegate = Subtract;
        MathOperation multiplyDelegate = Multiply;

        Console.WriteLine($"Результат сложения: {addDelegate(5, 3)}");
        Console.WriteLine($"Результат вычитания: {subtractDelegate(8, 4)}");
        Console.WriteLine($"Результат умножения: {multiplyDelegate(2, 6)}");
    }
}
