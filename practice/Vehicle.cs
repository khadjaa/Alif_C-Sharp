/*
1.  Создайте абстрактный класс "Vehicle" и определите в нем абстрактный метод "Drive". 
Затем создайте производные классы, представляющие различные типы транспортных средств, 
и реализуйте метод "Drive" для каждого из них. Создайте объекты разных классов 
и вызовите метод "Drive" для каждого из них.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public abstract class Vehicle
        {
            public string Model { get; set; }

            public Vehicle(string model)
            {
                Model = model;
            }

            public abstract void Drive();
        }

        public class Car : Vehicle
        {
            public Car(string model) : base(model) { }

            public override void Drive()
            {
                Console.WriteLine($"Car {Model} on road");
            }
        }

        class Motorcycle : Vehicle
        {
            public Motorcycle(string model) : base(model) { }

            public override void Drive()
            {
                Console.WriteLine($"Motorcycle {Model} on race");
            }
        }

        class Truck : Vehicle
        {
            public Truck(string model) : base(model) { }

            public override void Drive()
            {
                Console.WriteLine($"Truck {Model} on highway");
            }
        }

        private static void Main(string[] args)
        {
            Vehicle car = new Car("Toyota");
            Vehicle motorcycle = new Motorcycle("Harley Davidson");
            Vehicle truck = new Truck("Volvo");

            car.Drive();
            motorcycle.Drive();
            truck.Drive();
        }
    }
}