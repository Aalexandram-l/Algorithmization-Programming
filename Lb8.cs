/*
Лабораторная работа 8
31.03.2025
задание 1
с помощью лямбда реализовать сложение вычитание деление умножение 
задание 2
список из текстовых переменных и необходимо сделать выборку с помощью лямбда-выражений переменных начинающихся на А

задание 1
using System;
using System.Drawing;

class Program
{
    static void Main()
    {

        Func<double, double, double> summ = (x, y) => x + y;
        Func<double, double, double> subt = (x, y) => x - y;
        Func<double, double, double> mult = (x, y) => x * y;
        Func<double, double, double> div = (x, y) => y != 0 ? x / y : throw new DivideByZeroException("Деление на ноль!");

        Console.WriteLine("Введите значение для a");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение для b");
        double b = double.Parse(Console.ReadLine()); 

        Console.WriteLine($"Сложение: {a} + {b} = {summ(a, b)}");
        Console.WriteLine($"Вычитание: {a} - {b} = {subt(a, b)}");
        Console.WriteLine($"Умножение: {a} * {b} = {mult(a, b)}");
        Console.WriteLine($"Деление: {a} / {b} = {div(a, b)}");
    }
}


задание 2
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> words = new List<string>
        {
            "Apple",
            "Banana",
            "Avocado",
            "Cherry",
            "Apricot",
            "Grape",
            "Almond",
            "Alligator",
            "Ability",
            "Words"
        };

        var filtWords = words.Where(word => word.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine("Слова, начинающиеся на 'A':");
        foreach (var word in filtWords)
        {
            Console.WriteLine(word);
        }
    }
}

*/