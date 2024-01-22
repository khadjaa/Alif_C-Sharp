/*
Реализуйте небольшой программный проект или модифицируйте существующий, чтобы продемонстрировать 
применение принципов SOLID, уделяя особое внимание SRP, OCP и LSP. Ниже приведены шаги для практического занятия:

1.  Выберите небольшой программный проект или модуль, над которым вы уже работали, 
    или создайте новый, если это необходимо.

2.  Определите класс или компонент в проекте, который мог бы выиграть от следования 
    принципу единой ответственности (SRP). Переделайте этот класс так, чтобы он в большей 
    степени соответствовал SRP, разделив его обязанности на более мелкие, более сфокусированные классы.

3.  Если возможно, найдите возможность применить в проекте принцип открытости/закрытости (OCP). 
    Внесите изменения, чтобы обеспечить расширяемость без изменения существующего кода.

4.  Проверьте соблюдение принципа замещения Лискова (LSP) в иерархии классов вашего проекта. 
    Убедитесь, что подклассы могут быть заменены на базовые классы, не вызывая неожиданного поведения.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            private ITaxCalculator _taxCalculator;
            
            public void SetTaxCalculator(ITaxCalculator taxCalculator)
            {
                _taxCalculator = taxCalculator;
            }

            public decimal CalculateTax()
            {
                return _taxCalculator?.CalculateTax(this) ?? 0;
            }
        }

        public class CarInformation
        {
            private readonly Car _car;

            public CarInformation(Car car)
            {
                _car = car;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Make: {_car.Make}, Model: {_car.Model}, Year: {_car.Year}");
            }
        }
        
        public interface ITaxCalculator
        {
            decimal CalculateTax(Car car);
        }

        public class LuxuryCarTaxCalculator : ITaxCalculator
        {
            public decimal CalculateTax(Car car)
            {
                return car.Year > 2020 ? car.Year * 0.05m : 0;
            }
        }

        public class PetrolCar : Car
        {
            public int FuelTankCapacity { get; set; }

            public void Refuel()
            {
                Console.WriteLine($"Refueling {Make} {Model} with a fuel tank capacity of {FuelTankCapacity} gallons.");
            }
        }
        
        private static void Main(string[] args)
        {
            PetrolCar petrolCar = new()
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2022,
                FuelTankCapacity = 50
            };
            
            CarInformation carInfo = new (petrolCar);

            carInfo.DisplayInfo();

            LuxuryCarTaxCalculator taxCalculator = new();
            petrolCar.SetTaxCalculator(taxCalculator);

            decimal taxAmount = petrolCar.CalculateTax();
            Console.WriteLine($"Tax amount: {taxAmount}");

            petrolCar.Refuel();
        }
    }
}