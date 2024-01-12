/*
1. Напишите функцию на C#, которая возвращает кортеж с двумя значениями (например, имя и возраст человека).
Затем используйте "Деконструкцию" для получения и вывода этих значений.

2. Создайте класс "Книга" с полями для названия и автора книги. Реализуйте метод "Деконструкция" для
одновременного получения названия книги и автора. Затем создайте объект "Book" и используйте метод
"Deconstructing" для получения и вывода информации о книге.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public class Book
        {
            public string Name { get; set; }
            public string NameOfAuthor { get; set; }

            public (string name, string nameOfAuthor) GetInfoAboutBook()
            {
                string name = Name;
                string nameOfAuthor = NameOfAuthor;

                return (name, nameOfAuthor);
            }
        }

        static (string name, int age) GetInfoAboutPerson()
        {
            string name = "Ivan";
            int age = 20;
            return (name, age);
        }

        private static void Main(string[] args)
        {
            (string personName, int personAge) = GetInfoAboutPerson();
            Console.WriteLine($"Person name is {personName}, person age is {personAge}");

            Book book = new()
            {
                Name = "Clean Code",
                NameOfAuthor = "Martin"
            };

            (string name, string nameOfAuthor) = book.GetInfoAboutBook();
            Console.WriteLine($"Name of book is {name}, author of book is {nameOfAuthor}");
        }
    }
}