/*
1.  Использование блока try...catch для обработки определенного исключения. Вы можете создать
простую операцию деления, которая пытается разделить на ноль (например, 10 / 0) и поймать
исключение DivideByZeroException. В блоке catch выведите сообщение об ошибке на консоль.

2.  Используйте пользовательское исключение, создав свой собственный класс исключений (например, MyCustomException),
производный от Exception. В своей программе намеренно вызовите это пользовательское исключение с помощью ключевого слова throw.

3.  Используйте блок finally, чтобы гарантировать, что определенные ресурсы (например, файл, соединение
с базой данных или сетевое соединение) будут должным образом закрыты или освобождены независимо
от того, было ли выброшено исключение.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public class MyCustomException: Exception
        {
            public MyCustomException(): base() { }
            public MyCustomException(string message) : base(message) { }
            public MyCustomException(string message, Exception innerException) : base(message, innerException) { }
        }

        public static int DivideByZero()
        {
            throw new MyCustomException("Divide by zero");
        }
        
        private static void Main(string[] args)
        {
            try
            {
                int result = DivideByZero();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw new MyCustomException();
            }
            finally
            {
                Console.WriteLine("Closed all open processes");
            }
        }
    }
}