/*
Complete the function which takes two arguments and returns all numbers which are divisible by the given divisor. 
First argument is an array of numbers and the second is the divisor.
*/

using System;
using System.Collections.Generic;

public class Kata
{
  public static int[] DivisibleBy(int[] numbers, int divisor)
  {
        List<int> result = new List<int>();

        foreach (int num in numbers)
        {
            if (num % divisor == 0)
            {
                result.Add(num);
            }
        }

        return result.ToArray();
  }
}