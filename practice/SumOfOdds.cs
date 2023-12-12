namespace ConsoleApp1._8kyu;

public class SumOfOdds
{
    public static void Check()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int sumOfOdds = 0;

        foreach (int number in numbers)
        {
            if (number % 2 != 0)
            {
                sumOfOdds += number;
            }
        }
        Console.WriteLine(sumOfOdds);
    }
}