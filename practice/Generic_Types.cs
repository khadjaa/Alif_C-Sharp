/*
Реализуйте небольшую программу, чтобы продемонстрировать концепции ковариации и контравариации.
Ниже приведено пошаговое руководство по выполнению практического задания:

1.  Создайте иерархию классов, включающую базовый класс и один или несколько производных классов.

2.  Определите интерфейс, включающий методы с возвращаемыми типами и параметрами, относящиеся к базовому и производному классам.

3.  Реализуйте общий класс или метод, использующий ковариацию (неявное приведение производного типа к базовому)
и контравариацию (неявное приведение базового типа к производному).

4.  Создайте экземпляры производных классов и продемонстрируйте использование вашего общего класса или метода,
показав ковариацию и контравариацию.
*/

using System;

class Animal {}
class Cat : Animal {}
class Dog : Animal {}

interface IAnimalShelter<out T>
{
    T GetAnimal();
}

interface IAnimalFeeder<in T>
{
    void FeedAnimal(T animal);
}

class AnimalManager : IAnimalShelter<Animal>, IAnimalFeeder<Animal>
{
    public Animal GetAnimal()
    {
        Console.WriteLine("Animal shelter: Get any animal");
        return new Animal();
    }

    public void FeedAnimal(Animal animal)
    {
        Console.WriteLine("Animal feeder: Feeding any animal");
    }
}

class Program
{
    static void Main(string[] args)
    {
        AnimalManager manager = new AnimalManager();
        
        IAnimalShelter<Animal> shelter = manager;
        Animal catFromShelter = shelter.GetAnimal(); 
        
        IAnimalFeeder<Cat> feeder = manager;
        feeder.FeedAnimal(new Cat());
    }
}