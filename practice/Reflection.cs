/*
Применение атрибутов и отражения:
1.  Создайте класс Logger, представляющий пользовательский атрибут. Этот атрибут должен принимать в качестве 
параметра имя регистратора. Примените этот атрибут к нескольким классам в вашем проекте.

2.  Используя отражение, напишите метод, который обходит все классы в вашем проекте, проверяет наличие атрибута 
Logger и выводит имя класса и связанного с ним логгера.

Атрибуты и обобщения:
1.  Создайте обобщенный класс Cache<T>, который представляет собой кэш для объектов типа T. Добавьте пользовательский 
атрибут Cacheable и примените его к нескольким классам. Атрибут должен принимать строковый параметр, описывающий, 
как этот объект может быть кэширован.

2.  Используя отражение, реализуйте метод, который обходит все типы в вашем проекте, проверяет наличие атрибута 
Cacheable и выводит информацию о типе и описание кэширования.
*/

using System;
using System.Collections.Generic;
using System.Reflection;

public class LoggerAttribute : Attribute
{
    public string LoggerName { get; }

    public LoggerAttribute(string loggerName)
    {
        LoggerName = loggerName;
    }
}

public class CacheableAttribute : Attribute
{
    public string CacheDescription { get; }

    public CacheableAttribute(string cacheDescription)
    {
        CacheDescription = cacheDescription;
    }
}

public class Logger
{
    public static void LogClassesWithLoggerAttribute()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            LoggerAttribute loggerAttribute = (LoggerAttribute)Attribute.GetCustomAttribute(type, typeof(LoggerAttribute));
            if (loggerAttribute != null)
            {
                Console.WriteLine($"Class: {type.Name}, Logger: {loggerAttribute.LoggerName}");
            }
        }
    }

    public static void LogTypesWithCacheableAttribute()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            CacheableAttribute cacheableAttribute = (CacheableAttribute)Attribute.GetCustomAttribute(type, typeof(CacheableAttribute));
            if (cacheableAttribute != null)
            {
                Console.WriteLine($"Type: {type.Name}, Cache Description: {cacheableAttribute.CacheDescription}");
            }
        }
    }
}

public class Cache<T>
{
    public void CreateCache() { }
}

[Logger("Class1Logger")]
public class Class1 { }

[Logger("Class2Logger")]
public class Class2 { }

[Cacheable("Cacheable description for Class1")]
public class Class3 { }

[Cacheable("Cacheable description for Class2")]
public class Class4 { }

class Program
{
    static void Main(string[] args)
    {
        Logger.LogClassesWithLoggerAttribute();
        Logger.LogTypesWithCacheableAttribute();
    }
}