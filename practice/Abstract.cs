/*
1.  Представьте, что вы разрабатываете простую иерархию классов для зоопарка. Вам нужно представить 
    различных животных и их характеристики. Для этого вы будете использовать абстрактные классы, 
    виртуальные методы и наследование.
2.  Создайте абстрактный класс "Животное" со следующими свойствами и методами:
3.  Свойства: Имя (строка), Возраст (int)
4.  Методы: MakeSound(): Этот метод должен быть помечен как абстрактный и не имеет реализации. 
    Он представляет характерный звук животного. DisplayInfo(): Этот метод должен отображать имя, 
    возраст и звук, издаваемый животным.
5.  Создайте два производных класса от класса "Животное":
6.  Класс "Лев": Реализуйте метод "MakeSound" для рева.
7.  Класс "Слон": Реализуйте метод "MakeSound" для трубы.
8.  Создайте экземпляры классов "Лев" и "Слон", задайте их имена и возраст.
9.  Вызовите методы "MakeSound" и "DisplayInfo" для каждого экземпляра, чтобы наблюдать различные звуки, 
    издаваемые животными, и отображать информацию о них.
10. Добавьте дополнительные свойства или методы в производные классы, чтобы представить специфические 
    характеристики львов и слонов. Например, вы можете добавить свойство для представления 
    цвета гривы льва или длины хобота слона.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public abstract class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public abstract void MakeSound();
            public abstract void DisplayInfo();
        }

        public class Lion : Animal
        {
            public string ManeColor { get; set; }
            public override void MakeSound()
            {
                Console.WriteLine("Lion sound");
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Lion name: {Name}, Lion age {Age}, Lion mane color {ManeColor}");
            }
        }

        public class Elephant : Animal
        {
            public int TrunkLength { get; set; }
            public override void MakeSound()
            {
                Console.WriteLine("Elephant sound");
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Elephant name: {Name}, Elephant age {Age}, Elephant trunk length {TrunkLength}m");
            }
        }

        private static void Main(string[] args)
        {
            Lion lion = new()
            {
                Name = "Lev",
                Age = 10,
                ManeColor = "Orange"
            };

            Elephant elephant = new()
            {
                Name = "Hobot",
                Age = 20,
                TrunkLength = 2
            };

            lion.MakeSound();
            elephant.MakeSound();
            
            lion.DisplayInfo();
            elephant.DisplayInfo();
        }
    }
}