/*
1.  Создайте иерархию классов для представления различных типов животных, таких как "Собака",
"Кошка" и "Птица". Используйте наследование для создания производных классов от базового класса
"Животное". Добавьте в базовый класс виртуальный метод "IssueSound", который будет переопределяться
в производных классах для описания звуков, издаваемых каждым видом животных. Создайте объекты разных
классов и вызовите метод "MakeSound" для каждого из них через базовый класс.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                Name = name;
            }

            public virtual void MakeSound()
            {
                Console.WriteLine("Животное издает звук");
            }
        }

        public class Dog : Animal
        {
            public Dog(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine("Гав-гав!");
            }
        }

        public class Cat : Animal
        {
            public Cat(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine("Мяу-мяу!");
            }
        }

        public class Bird : Animal
        {
            public Bird(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine("Чирик-чирик!");
            }
        }

        private static void Main(string[] args)
        {
            Animal dog = new Dog("sharik");
            Animal cat = new Cat("murzik");
            Animal bird = new Bird("solovey");

            Console.WriteLine($"Sound of {dog.Name}:");
            dog.MakeSound();

            Console.WriteLine($"Sound of {cat.Name}:");
            cat.MakeSound();

            Console.WriteLine($"Sound of {bird.Name}:");
            bird.MakeSound();
        }
    }
}