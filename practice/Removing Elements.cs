/*
Take an array and remove every second element from the array. Always keep the first element and start removing with the next element.
*/

using System.Collections.Generic;

public static class Kata
{
    public static object[] RemoveEveryOther(object[] arr)
    {
        List<object> result = new List<object>();

        for (int i = 0; i < arr.Length; i += 2)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }
}
