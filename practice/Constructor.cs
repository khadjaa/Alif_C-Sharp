/*
1. Создайте класс C# с именем "Студент" со следующими атрибутами: Имя (строка), Возраст (int), Средний балл (double).
2. Реализуйте первичный конструктор для класса "Студент", принимающий в качестве параметров все три атрибута.
3. Создайте экземпляр класса "Студент" с помощью первичного конструктора и инициализируйте его данными из примера.
4. Реализуйте статический конструктор для класса "Студент", который при инициализации класса устанавливает 
статическое поле "TotalStudents" в 0.
5. Создайте несколько экземпляров класса "Студент", используя первичный конструктор, и увеличивайте значение 
"TotalStudents" в статическом конструкторе каждый раз, когда создается новый экземпляр.
6. Напишите метод в классе "Студент", который выводит данные о студенте (имя, возраст, средний балл) и общее 
количество студентов (TotalStudents) с помощью статического метода.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double AverageScore { get; set; }
            public static int TotalStudents { get; private set; }
            public Student(string name, int age, double averageScore)
            {
                Name = name;
                Age = age;
                AverageScore = averageScore;

                TotalStudents++;
            }

            static Student()
            {
                TotalStudents = 0;
            }
            
            public static void PrintStudentInfo(Student student)
            {
                Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Average Score: {student.AverageScore}");
                Console.WriteLine($"Total Students: {TotalStudents}");
                Console.WriteLine();
            }
        }
        
        private static void Main(string[] args)
        {
            Student student1 = new("Bakha", 24, 4);
            Student student2 = new("Islam", 21, 4.6);
            
            Student.PrintStudentInfo(student1);
            Student.PrintStudentInfo(student2);
        }
    }
}