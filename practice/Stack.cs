/*
1. Stack:
Напишите программу с использованием Stack<T> для обработки стека операций (например, математических выражений).
Создайте метод для изменения порядка элементов в Stack<T> без использования сторонних коллекций.

2. ArrayList:
Реализуйте программу, использующую ArrayList для хранения данных о студентах (имя, возраст, оценки).

3. Hashtable:
Создайте Hashtable, используя объекты в качестве ключей, и реализуйте методы для добавления, удаления и поиска элементов.
*/

using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<char> stack = new Stack<char>();
        string expression = "((3+5)*2)";

        foreach (char c in expression)
        {
            if (c == '(' || c == '+' || c == '-' || c == '*' || c == '/')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Peek() != '(')
                {
                    Console.Write(stack.Pop() + " ");
                }
                stack.Pop(); 
            }
            else
            {
                Console.Write(c + " ");
            }
        }

        ArrayList students = new ArrayList();
        students.Add(new Student("Alice", 20, new List<int> { 85, 90, 88 }));
        students.Add(new Student("Bob", 22, new List<int> { 75, 82, 79 }));

        foreach (Student student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
            Console.Write("Grades: ");
            foreach (int grade in student.Grades)
            {
                Console.Write(grade + " ");
            }
            Console.WriteLine();
        }

        Hashtable hashtable = new Hashtable();
        hashtable.Add(new KeyObject("Key1"), "Value1");
        hashtable.Add(new KeyObject("Key2"), "Value2");

        hashtable.Remove(new KeyObject("Key1"));

        Console.WriteLine(hashtable[new KeyObject("Key2")]);
    }

    class Student
    {
        public string Name { get; }
        public int Age { get; }
        public List<int> Grades { get; }

        public Student(string name, int age, List<int> grades)
        {
            Name = name;
            Age = age;
            Grades = grades;
        }
    }

    class KeyObject
    {
        public string Key { get; }

        public KeyObject(string key)
        {
            Key = key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is KeyObject other)
            {
                return Key.Equals(other.Key);
            }
            return false;
        }
    }
}
