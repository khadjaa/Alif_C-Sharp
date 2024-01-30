/*
1. Indexer:
Создайте класс, использующий индексатор для доступа к элементам внутреннего массива. Реализуйте аксессоры get и set.
Попробуйте перегрузить индексатор так, чтобы он поддерживал двумерный массив.

2. List:
Напишите программу с использованием List<T>, которая хранит список имен. Реализуйте добавление и удаление имен, 
а также отображение списка на экране.
Сравните производительность операций добавления элементов в List<T> и ArrayList для различных типов данных T.

3. Dictionary:
Создайте словарь (Dictionary<TKey, TValue>) для хранения контактной информации (например, имени и номера телефона). 
Реализуйте операции добавления, удаления и поиска по ключу.

4. Queue:
Используйте Queue<T> для имитации очереди при обслуживании клиентов. Реализуйте операции добавления и удаления клиентов из очереди.

5. SortedList:
Реализуйте простой пример использования SortedList для хранения и сортировки списка книг по их названиям. 
Добавьте операции для добавления и удаления книг из списка.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        IndexerExample example = new IndexerExample(9);

        example[0] = 1;
        Console.WriteLine(example[0]);

        example[1, 1] = 2;
        Console.WriteLine(example[1, 1]);

        List<string> namesList = new List<string>();
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        for (int i = 0; i < 100000; i++)
        {
            namesList.Add("Name" + i.ToString());
        }
        stopwatch.Stop();
        Console.WriteLine($"Время добавления в List<T>: {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();
        for (int i = 0; i < 100000; i++)
        {
            namesList.RemoveAt(0);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время удаления из List<T>: {stopwatch.ElapsedMilliseconds} мс");

        Dictionary<string, string> contacts = new Dictionary<string, string>();

        contacts.Add("John", "123456789");
        contacts.Add("Alice", "987654321");

        contacts.Remove("Alice");

        if (contacts.ContainsKey("John"))
        {
            Console.WriteLine("Номер телефона John: " + contacts["John"]);
        }

        Queue<string> customerQueue = new Queue<string>();

        customerQueue.Enqueue("Client1");
        customerQueue.Enqueue("Client2");
        customerQueue.Enqueue("Client3");

        while (customerQueue.Count > 0)
        {
            Console.WriteLine("Обслуживается клиент: " + customerQueue.Dequeue());
        }

        SortedList<string, string> bookList = new SortedList<string, string>();

        bookList.Add("B", "Book B");
        bookList.Add("C", "Book C");
        bookList.Add("A", "Book A");

        bookList.Remove("B");

        foreach (var book in bookList)
        {
            Console.WriteLine("Title: " + book.Value);
        }
    }
}

class IndexerExample
{
    private int[] array;

    public IndexerExample(int size)
    {
        array = new int[size];
    }

    public int this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public int this[int row, int column]
    {
        get { return array[row * 3 + column]; }
        set { array[row * 3 + column] = value; }
    }
}
