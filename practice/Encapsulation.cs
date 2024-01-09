/*
2.  Создайте класс "Студент" с приватными полями для имени, возраста и среднего балла. 
Определите методы для установки и получения значений этих полей. Создайте объекты класса
"Студент" и используйте методы для установки и получения информации о студентах. 
Расширьте класс "Студент", добавив проверку для полей, чтобы возраст не мог быть отрицательным, 
а средний балл находился в допустимом диапазоне (например, от 0 до 100). В методах для 
установки значений убедитесь, что данные соответствуют условиям проверки.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public class Student
        {
            private string Name { get; set; }
            private int Age { get; set; }
            private double AverageScore { get; set; }

            public void GetName() => Console.WriteLine($"Student name is {Name}");
            public string SetName(string name) => Name = name;
            
            public void GetAge() => Console.WriteLine($"Student age is {Age}");
            public void SetAge(int age) 
            {
                if (age > 0)
                {
                    Age = age;
                }
                else
                {
                    Console.WriteLine("Student age must be positive");
                }
            }
            
            public void GetAverageScore() => Console.WriteLine(AverageScore);
            public void SetAverageScore(double averageScore) 
            {
                if (averageScore > 0 && averageScore < 100)
                {
                    AverageScore = averageScore;
                }
                else
                {
                    Console.WriteLine("Student average score must be from 0 to 100");
                }
            }
        }
        
        private static void Main(string[] args)
        {
            Student student = new();
            
            student.SetName("Andri");
            student.GetName();
            
            student.SetAge(18);
            student.GetAge();
            
            student.SetAverageScore(101);
            student.GetAverageScore();
        }
    }
}