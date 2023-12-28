/*1. Реализуйте класс для представления комплексных чисел с действительной и мнимой частями. 
     Перегрузите операторы сложения, вычитания и умножения для этого класса. Создайте приложение, 
     демонстрирующее использование этих перегруженных операторов.
  
  2. Реализуйте класс с именем для представления матрицы 2x2 из целых чисел. Перегрузите операторы
     сложения и умножения для этого класса. Создайте приложение, демонстрирующее использование этих перегруженных операторов.
  
  3. Напишите метод расширения для массива, который вычисляет и возвращает сумму всех элементов в списке.
     Используйте этот метод расширения в приложении для нахождения суммы элементов в списке целых чисел.
  
  4. Напишите метод расширения для System.String, который подсчитывает количество вхождений указанной 
     подстроки в строку. Используйте этот метод расширения для поиска вхождений определенной подстроки в заданную строку.*/

namespace ConsoleApp1
{
    
    public static class ArrayExtensions
    {
        public static int SumElements(this int[] array)
        {
            return array.Sum();
        }
    }
    
    public static class StringExtensions
    {
        public static int CountOccurrences(this string str, string substring)
        {
            int count = 0;
            int index = 0;

            while ((index = str.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
            {
                index += substring.Length;
                count++;
            }

            return count;
        }
    }
    
    internal class Program
    {
        public class ComplexNumber
        {
            public double Real { get; set; }
            public double Imaginary { get; set; }

            public ComplexNumber(double real, double imaginary)
            {
                Real = real;
                Imaginary = imaginary;
            }

            public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
            }

            public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
            }

            public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.Real * b.Real, a.Imaginary * b.Imaginary);
            }
        }
        
        class Matrix2x2
        {
            public int A, B, C, D;

            public Matrix2x2(int a, int b, int c, int d)
            {
                A = a;
                B = b;
                C = c;
                D = d;
            }
            
            public static Matrix2x2 operator +(Matrix2x2 matrix1, Matrix2x2 matrix2)
            {
                return new Matrix2x2(matrix1.A + matrix2.A, matrix1.B + matrix2.B, matrix1.C + matrix2.C, matrix1.D + matrix2.D);
            }

            public static Matrix2x2 operator *(Matrix2x2 matrix1, Matrix2x2 matrix2)
            {
                int resultA = matrix1.A * matrix2.A + matrix1.B * matrix2.C;
                int resultB = matrix1.A * matrix2.A + matrix1.B * matrix2.D;
                int resultC = matrix1.C * matrix2.A + matrix1.D * matrix2.C;
                int resultD = matrix1.C * matrix2.B + matrix1.D * matrix2.D;

                return new Matrix2x2(resultA, resultB, resultC, resultD);
            }
        }
        
        public static void Complex()
        {
            ComplexNumber complex1 = new(5, 6);
            ComplexNumber complex2 = new(7, 8);
            
            ComplexNumber res1 = complex1 + complex2;
            ComplexNumber res2 = complex1 - complex2;
            ComplexNumber res3 = complex1 * complex2;
            
            Console.WriteLine($"Результат сложения действительной {res1.Real} и мнимой {res1.Imaginary} будет {res1.Real + res1.Imaginary}");
            Console.WriteLine($"Результат вычитания действительной {res2.Real} и мнимой {res2.Imaginary} будет {res2.Real - res2.Imaginary}");
            Console.WriteLine($"Результат умножения действительной {res3.Real} и мнимой {res3.Imaginary} будет {res3.Real * res3.Imaginary}");
        }

        public static void Matrix()
        {
            Matrix2x2 matrix1 = new(1, 2, 3, 4);
            Matrix2x2 matrix2 = new(1, 2, 3, 4);

            Matrix2x2 res1 = matrix1 + matrix2;
            Matrix2x2 res2 = matrix1 * matrix2;
            Console.WriteLine($"Результат сложения матриц {res1.A} {res1.B} {res1.C} {res1.D}");
            Console.WriteLine($"Результат умножения матриц {res2.A} {res2.B} {res2.C} {res2.D}");
        }

        public static void Array()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int sum = numbers.SumElements();
            Console.WriteLine($"Сумма элементов массива: {sum}");
        }

        public static void SystemString()
        {
            string mainString = "Hello, hello, hello, world!";
            string substringToFind = "hello";
            int occurrences = mainString.CountOccurrences(substringToFind);
            Console.WriteLine($"Substring '{substringToFind}' occurs {occurrences} times in the string.");
        }
        
        private static void Main(string[] args)
        {
            Complex();
            Matrix();
            Array();
            SystemString();
        }
    }
}