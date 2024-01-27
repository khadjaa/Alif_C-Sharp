/*
1.  Создайте простое консольное приложение на C#, используя общую коллекцию List<T>. Добавьте в 
коллекцию несколько элементов разных типов и выведите их на экран.

2.  Напишите код с использованием общей коллекции Dictionary<TKey, TValue>. Добавьте несколько 
пар ключ-значение и реализуйте поиск элемента по ключу.

3.  Создайте метод итератора, который генерирует последовательность чисел Фибоначчи. Используйте 
этот итератор для вывода первых 10 чисел Фибоначчи на консоль.

4.  Используйте несколько коллекций из System.Collections.Concurrent для реализации многопоточности 
в простом скрипте. Например, попробуйте использовать ConcurrentQueue для безопасного добавления 
и удаления элементов из разных потоков.

5.  Реализуйте простую функцию для поиска элемента в списке с помощью интерфейса IList. 
Попробуйте использовать различные методы, такие как IndexOf и Contains.

6.  Создайте класс, реализующий интерфейс IEnumerable, и используйте его для итераций по собственным данным. 
Выведите результаты на экран.*/


using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Пункт 1: Простое консольное приложение с использованием List<T>
        List<object> myList = new List<object>();
        myList.Add(10);
        myList.Add("Hello");
        myList.Add(3.14);

        Console.WriteLine("List");

        foreach (object item in myList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\n---\n");

        // Пункт 2: Использование Dictionary<TKey, TValue> с поиском элемента по ключу
        Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        myDictionary.Add(1, "One");
        myDictionary.Add(2, "Two");
        myDictionary.Add(3, "Three");
        
        Console.WriteLine("Dictionary");

        Console.WriteLine("Value for key 2: " + myDictionary[2]);

        Console.WriteLine("\n---\n");

        // Пункт 3: Метод итератора для генерации чисел Фибоначчи
        Console.WriteLine("FibonacciIterator");
        FibonacciIterator fib = new FibonacciIterator();
        foreach (int num in fib)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("\n---\n");

        // Пункт 4: Использование ConcurrentQueue для безопасного добавления и удаления элементов из разных потоков
        ConcurrentQueue<int> myQueue = new ConcurrentQueue<int>();
        Console.WriteLine("ConcurrentQueue");

        Task producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
                Console.WriteLine($"Produced: {i}");
            }
        });

        Task consumer = Task.Run(() =>
        {
            int item;
            while (!myQueue.IsEmpty)
            {
                if (myQueue.TryDequeue(out item))
                {
                    Console.WriteLine($"Consumed: {item}");
                }
            }
        });

        Task.WaitAll(producer, consumer);

        Console.WriteLine("\n---\n");

        // Пункт 5: Простая функция для поиска элемента в списке с помощью интерфейса IList
        List<int> myListForSearch = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("IList");

        Console.WriteLine(myListForSearch.IndexOf(3)); // выводит индекс элемента со значением 3
        Console.WriteLine(myListForSearch.Contains(6)); // выводит True, если список содержит элемент со значением 6, иначе False

        Console.WriteLine("\n---\n");

        // Пункт 6: Создание класса, реализующего интерфейс IEnumerable
        Console.WriteLine("IEnumerable");

        MyData myData = new MyData();
        foreach (int item in myData)
        {
            Console.WriteLine(item);
        }
    }
}

class FibonacciIterator : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        int a = 0, b = 1;
        for (int i = 0; i < 10; i++)
        {
            yield return a;
            int temp = a;
            a = b;
            b = temp + b;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class MyData : IEnumerable<int>
{
    private List<int> data = new List<int>();

    public MyData()
    {
        for (int i = 0; i < 10; i++)
        {
            data.Add(i);
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
