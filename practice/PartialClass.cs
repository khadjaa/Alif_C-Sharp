namespace ConsoleApp1
{
    internal class Program
    {
        partial class MyClass
        {
            public void Method1() 
            {      
                Console.WriteLine("Method1");
            }
        }
        
        partial class MyClass
        {
            public void Method2()
            {
                Console.WriteLine("Method2");
            }
        }
        /*Partial classes полезны при генерации кода, например, при использовании
         средств визуального дизайна. Каждый файл содержит часть функциональности класса,
         и компилятор объединяет их в один класс.*/
        
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}