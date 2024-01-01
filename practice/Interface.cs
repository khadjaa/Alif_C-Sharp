/*
1.  Создайте интерфейс "IVehicle" со следующими членами:
2.  Свойство "Скорость" (двойная).
3.  Метод "StartEngine", реализация которого по умолчанию выводит сообщение "Engine started".
4.  Создайте два класса, "Car" и "Bicycle", которые реализуют интерфейс "IVehicle".
5.  В классе "Car" реализуйте свойство "Speed" и переопределите метод "StartEngine",
    чтобы он выводил сообщение "Двигатель автомобиля запущен".
6.  В классе "Велосипед" реализуйте свойство "Скорость" и переопределите метод "StartEngine",
    чтобы он отображал "Двигатель велосипеда запущен".
7.  Создайте экземпляры классов "Автомобиль" и "Велосипед", установите их свойства скорости и
    вызовите метод "StartEngine" для каждого экземпляра.

Practice 2:
1.  Создайте интерфейс "IMath" со следующими статическими членами:
2.  Статический метод "Add", который принимает два целых числа в качестве параметров и возвращает их сумму.
3.  Статический метод "Multiply", который принимает два целых числа в качестве параметров и возвращает их произведение.
4.  Реализуйте интерфейс "IMath" в классе "Calculator".
5.  Реализуйте методы "Add" и "Multiply" в классе "Calculator".
6.  Создайте экземпляр класса "Калькулятор" и используйте статические методы для выполнения операций сложения и умножения.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public interface IVehicle
        {
            public double Speed { get; set; }
            void StartEngine() => Console.WriteLine("Engine started");
        }

        public class Car : IVehicle
        {
            public double Speed { get; set; }

            public void StartEngine()
            {
                Console.WriteLine("Двигатель автомобиля запущен");
            }
        }

        public class Bicycle : IVehicle
        {
            public double Speed { get; set; }

            public void StartEngine()
            {
                Console.WriteLine("Двигатель велосипеда запущен");
            }
        }
        
        public interface IMath
        {
            int Add(int a, int b);
            int Multiply(int a, int b);
        }

        public class Calculator : IMath
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public int Multiply(int a, int b)
            {
                return a * b;
            }
        }

        private static void Main(string[] args)
        {
            Car car = new()
            {
                Speed = 125.5
            };

            Bicycle bicycle = new()
            {
                Speed = 40.5
            };
            
            car.StartEngine();
            bicycle.StartEngine();
            
            Calculator calculator = new Calculator();

            int sum = calculator.Add(5, 3);
            Console.WriteLine("Sum: " + sum);

            int product = calculator.Multiply(4, 7);
            Console.WriteLine("Product: " + product);
        }
    }
}