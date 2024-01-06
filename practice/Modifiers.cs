/*
1. Создайте собственные классы и структуры, используя различные атрибуты доступа.
Создайте методы и поля с различными атрибутами доступа, чтобы продемонстрировать различия
в их доступности в разных частях вашего кода. Попробуйте вызвать или получить доступ
к членам класса из разных областей вашего проекта, чтобы увидеть,
как атрибуты доступа влияют на доступ к членам класса.
*/

using ConsoleApp1._8kyu;

namespace ConsoleApp1
{
    internal class Program
    {
        public abstract class TransitPlace
        {
            public string Name { get; set; }
            public string Place { get; set; }
            protected int ProtectedField;
            
            public void DisplayInfo()
            {
                Console.WriteLine($"TransitPlace: {Name}, {Place}");
            }
        }
        
        public class Pilot
        {
            public string Name { get; set; }
            public int HoursOfFlying { get; set; }
        }
        
        public class Airport : TransitPlace
        {
            public Airport(int count)
            {
                SetCountOfSecurity(count);
            }

            public Pilot Pilot = new()
            {
                Name = "Ivan",
                HoursOfFlying = 1000
            };

            private int CountOfSecurity { get; set; }

            private void SetCountOfSecurity(int count)
            {
                CountOfSecurity = count;
            }
        }

        private static void Main(string[] args)
        {
            Airport airport = new(50)
            {
                Name = "Domodedovo",
                Place = "Land"
            };

            Console.WriteLine(airport.Pilot.Name);
            airport.DisplayInfo();
        }
    }
}