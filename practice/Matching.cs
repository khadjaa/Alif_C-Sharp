/*
1.   Напишите функцию на C#, которая принимает на вход объект и с помощью "Pattern Matching" определяет,
является ли он строкой. Если это строка, выведите ее длину, если нет, выведите сообщение "Это не строка".


2.    Разработайте программу, которая принимает на вход температуру в градусах по Фаренгейту и, используя
"Подбор шаблонов", определяет состояние воды (пар, жидкость, лед) при этой температуре.
Для определения состояния используйте следующие значения:
Температура менее 32°F - вода находится в состоянии льда.
Температура от 32°F до 212°F - вода в жидком состоянии.
Температура выше 212°F - вода находится в парообразном состоянии.
*/

namespace ConsoleApp1
{
    internal class Program
    {
      
        static void CheckAndPrintLength(object obj)
        {
            if (obj is string str)
            {
                Console.WriteLine($"Длина строки: {str.Length}");
            }
            else
            {
                Console.WriteLine("Это не строка");
            }
        }
        
        static void DetermineWaterState(double temperature)
        {
            switch (temperature)
            {
                case var t when t < 32:
                    Console.WriteLine("Вода находится в состоянии льда."); 
                    break;
                case var t when t >= 32 && t <= 212:
                    Console.WriteLine("Вода в жидком состоянии.");
                    break;
                case var t when t > 212:
                    Console.WriteLine("Вода находится в парообразном состоянии.");
                    break;
                default:
                    Console.WriteLine("Некорректная температура.");
                    break;
            }
        }
        
        private static void Main(string[] args)
        {
            object obj = "Пример строки";
            CheckAndPrintLength(obj);

            obj = 123;
            CheckAndPrintLength(obj);

            DetermineWaterState(44);
        }
    }
}