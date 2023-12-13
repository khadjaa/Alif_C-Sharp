namespace ConsoleApp1._8kyu;

public class Sum
{
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    private static void Main(string[] args)
    {
        int sum = AddNumbers(4, 10);
        Console.WriteLine($"Сумма чисел 4 и 10 равна: {sum}");
    }
}