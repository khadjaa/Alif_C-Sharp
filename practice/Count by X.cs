/*
Create a function with two arguments that will return an array of the first n multiples of x.

Assume both the given number and the number of times to count will be positive numbers greater than 0.

Return the results as an array or list ( depending on language ).
*/

using System;

public static class Kata
{
    public static int[] CountBy(int x, int n)
    {
        int[] result = new int[n];

        for (int i = 1; i <= n; i++)
        {
            result[i - 1] = x * i;
        }

        return result;
    }
}
