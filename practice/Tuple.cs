/*
 1. Создайте программу на C#, моделирующую простую систему заказов электронной коммерции.
 Используйте анонимные типы для представления заказов клиентов. Каждый заказ должен иметь такие свойства,
 как OrderId, CustomerName, ProductName и Price. Инициализируйте коллекцию объектов анонимного типа и отобразите их.

 2. Создайте программу на C#, моделирующую базовую систему управления запасами. Используйте кортежи для
 представления информации о товарах, включая ProductID, ProductName и Price. Добавьте функцию для расчета
 общей стоимости запасов на основе данных кортежей. .NET
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public static void DoAnon()
        {
            var orders = new[]
            {
                new { OrderId = 1, CustomerName = "Ivanov", ProductName = "Phone", Price = 500 },
                new { OrderId = 2, CustomerName = "Petrov", ProductName = "Laptop", Price = 1200 },
            };

            foreach (var order in orders)
            {
                Console.WriteLine($"OrderID: {order.OrderId}, Customer: {order.CustomerName}, Product: {order.ProductName}, Price: {order.Price}");
            }
        }

        public static void DoTuples()
        {
            var products = new[]
            {
                (ProductID: 1, ProductName: "Monitor", Price: 200.1),
                (ProductID: 2, ProductName: "Scanner", Price: 100),
                (ProductID: 3, ProductName: "Keyboard", Price: 30)
            };

            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.ProductName}, Price: {product.Price}");
            }
            
            double totalCost = CalculateTotalCost(products);
            
            Console.WriteLine($"Total coast of products is : {totalCost}");
        }

        static double CalculateTotalCost((int ProductID, string ProductName, double Price)[] products)
        {
            double totalCost = 0;

            foreach (var product in products)
            {
                totalCost += product.Price;
            }

            return totalCost;
        }
        
        private static void Main1(string[] args)
        {
            DoAnon();
            DoTuples();
        }
    }
}