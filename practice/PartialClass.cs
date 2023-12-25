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
            partial void PartialMethod();
        }
        
        partial class MyClass
        {
            public void Method2()
            {
                Console.WriteLine("Method2");
            }
            
            partial void PartialMethod()
            {
                Console.WriteLine("PartialMethod2");
            }
            
            /*Partial methods полезны, когда вы хотите оставить возможность для генератора кода или
             других инструментов вставить дополнительный код, и этот код может быть или 
             не быть реализован в другом месте.*/
        }
        
        /*Partial classes полезны при генерации кода, например, при использовании
         средств визуального дизайна. Каждый файл содержит часть функциональности класса, 
         и компилятор объединяет их в один класс.*/
        
        sealed class MySealedClass
        {
            // Sealed классы не могут быть унаследованы.
            // Это полезно если мы не хотим чтобы другие классы наследовали функциональность нашего класса.
        }
        
        public static class MyStaticClass
        {
            public static void StaticMethod1()
            {
                Console.WriteLine("StaticMethod1");
            }

            public static void StaticMethod2()
            {
                Console.WriteLine("StaticMethod2");
            }
        }
        
        /*Static классы предоставляют функциональность, которая не требует создания экземпляра объекта.
         Static методы могут быть вызваны без создания объекта, что удобно для функций, 
         не зависящих от состояния объекта.*/
        
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}