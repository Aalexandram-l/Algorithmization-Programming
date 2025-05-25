/*
Лабораторная работа 14
12.05.2025
даны данные о пользователях, каждый пользователь характеризуется фио, годом рождения, наличие компьютера, 
если комп есть,то определить марку год выпуска, установленнная система
с помощью меню сделать выборку 
1. всех у которых нет компа
2. пользователи, у которых есть комп, сгруппировать по системам
3. по марке компа
4. определить каких пользователей больше с компом или без

выполнить с использованием библиотеки линк



using System;
using System.Collections.Generic;
using System.Linq;

class Computer
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public string OS { get; set; }
}

class User
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public Computer Computer { get; set; }  

class Program
{
    static void Main()
    {
        var users = new List<User>
        {
            new User { FullName = "Иванов Иван Иванович", BirthYear = 1990, Computer = null },
            new User { FullName = "Петров Петр Петрович", BirthYear = 1985, Computer = new Computer { Brand = "HP", Year = 2018, OS = "Windows" } },
            new User { FullName = "Сидорова Мария", BirthYear = 1995, Computer = new Computer { Brand = "Dell", Year = 2020, OS = "Windows" } },
            new User { FullName = "Кузнецов Алексей", BirthYear = 1980, Computer = new Computer { Brand = "Apple", Year = 2019, OS = "macOS" } },
            new User { FullName = "Морозова Елена", BirthYear = 1992, Computer = null },
            new User { FullName = "Васильев Сергей", BirthYear = 1988, Computer = new Computer { Brand = "HP", Year = 2017, OS = "Linux" } },
        };

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Все пользователи без компьютера");
            Console.WriteLine("2. Пользователи с компьютером по заданной ОС");
            Console.WriteLine("3. Пользователи с компьютером по заданной марке");
            Console.WriteLine("4. Сравнить количество пользователей с компьютером и без");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var noComputer = users.Where(u => u.Computer == null);
                    Console.WriteLine("\nПользователи без компьютера:");
                    foreach (var u in noComputer)
                        Console.WriteLine($"- {u.FullName}, год рождения: {u.BirthYear}");
                    break;

                case "2":
                    Console.Write("Введите ОС (например, Windows, macOS, Linux): ");
                    string osInput = Console.ReadLine()?.Trim();

                    var byOS = users
                        .Where(u => u.Computer != null &&
                                    string.Equals(u.Computer.OS, osInput, StringComparison.OrdinalIgnoreCase));

                    if (byOS.Any())
                    {
                        Console.WriteLine($"\nПользователи с ОС \"{osInput}\":");
                        foreach (var u in byOS)
                            Console.WriteLine($"- {u.FullName} (марка: {u.Computer.Brand}, год: {u.Computer.Year})");
                    }
                    else
                    {
                        Console.WriteLine($"Пользователей с ОС \"{osInput}\" не найдено.");
                    }
                    break;

                case "3":
                    Console.Write("Введите марку компьютера (например, HP, Dell, Apple): ");
                    string brandInput = Console.ReadLine()?.Trim();

                    var byBrand = users
                        .Where(u => u.Computer != null &&
                                    string.Equals(u.Computer.Brand, brandInput, StringComparison.OrdinalIgnoreCase));

                    if (byBrand.Any())
                    {
                        Console.WriteLine($"\nПользователи с маркой компьютера \"{brandInput}\":");
                        foreach (var u in byBrand)
                            Console.WriteLine($"- {u.FullName} (ОС: {u.Computer.OS}, год: {u.Computer.Year})");
                    }
                    else
                    {
                        Console.WriteLine($"Пользователей с маркой \"{brandInput}\" не найдено.");
                    }
                    break;

                case "4":
                    int withComp = users.Count(u => u.Computer != null);
                    int withoutComp = users.Count(u => u.Computer == null);

                    Console.WriteLine($"\nПользователей с компьютером: {withComp}");
                    Console.WriteLine($"Пользователей без компьютера: {withoutComp}");

                    if (withComp > withoutComp)
                        Console.WriteLine("Пользователей с компьютером больше.");
                    else if (withoutComp > withComp)
                        Console.WriteLine("Пользователей без компьютера больше.");
                    else
                        Console.WriteLine("Количество пользователей с компьютером и без компьютера равно.");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
*/


