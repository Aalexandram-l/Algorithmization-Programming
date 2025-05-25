/* Лабороторная работа 12
 28.04.2025

задание 1
дан класс телефон
поля: номер телефона, фио владельца,оператор, год подключения
необходимо сделаать запросы с использованием библиотеки линк
1. выдать номера телефонов сгруппированных по году подключения 
2. выдать номера телефонов сгруппированных по оператору
3. выдать телефон по заданному имени владельца
(выдать телефон - выдать сведения)
сделать меню 

задание 2
структуру сами
база данных бассейн 
сведения о тренерах, о клиентах
необходимо с использованием лика
выдавать сведения сгруппированные по датам посещения 
по тренерам 
по клиенту с наибольшим временем посещения (по кол-ву дат)
и выдать все даты посещения каждого клиента 
сделать меню

Задание 1
using System;
using System.Collections.Generic;
using System.Linq;

public class Phone
{
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Operator { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        var phones = new List<Phone>
        {
            new Phone { PhoneNumber = "123-456", Name = "Иванов И.И.", Operator = "МегаФон", Year = 2020 },
            new Phone { PhoneNumber = "234-567", Name = "Петров П.П.", Operator = "Билайн", Year = 2021 },
            new Phone { PhoneNumber = "345-678", Name = "Сидоров С.С.", Operator = "МегаФон", Year = 2020 },
            new Phone { PhoneNumber = "456-789", Name = "Кузнецова А.А.", Operator = "Теле2", Year = 2022 }
        };

        while (true)
        {
            Console.WriteLine("\nМЕНЮ:");
            Console.WriteLine("1. Вывести телефоны по году подключения");
            Console.WriteLine("2. Вывести телефоны по оператору");
            Console.WriteLine("3. Найти телефон по имени владельца");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите год подключения: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        var filteredByYear = phones.Where(p => p.Year == year).ToList();
                        if (filteredByYear.Any())
                        {
                            Console.WriteLine($"\nТелефоны, подключённые в {year} году:");
                            foreach (var phone in filteredByYear)
                                Console.WriteLine($"  {phone.PhoneNumber} - {phone.Name} ({phone.Operator})");
                        }
                        else
                        {
                            Console.WriteLine("Нет телефонов с таким годом подключения.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат года.");
                    }
                    break;

                case "2":
                    Console.Write("Введите имя оператора: ");
                    string op = Console.ReadLine();
                    var filteredByOperator = phones.Where(p => p.Operator.Equals(op, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (filteredByOperator.Any())
                    {
                        Console.WriteLine($"\nТелефоны оператора {op}:");
                        foreach (var phone in filteredByOperator)
                            Console.WriteLine($"  {phone.PhoneNumber} - {phone.Name} (Год: {phone.Year})");
                    }
                    else
                    {
                        Console.WriteLine("Нет телефонов с таким оператором.");
                    }
                    break;

                case "3":
                    Console.Write("Введите ФИО владельца: ");
                    string name = Console.ReadLine();
                    var found = phones.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    if (found != null)
                        Console.WriteLine($"Номер: {found.PhoneNumber}, Оператор: {found.Operator}, Год подключения: {found.Year}");
                    else
                        Console.WriteLine("Владелец не найден.");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }
}

Задание 2

using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public string Name { get; set; }
}

public class Client
{
    public string Name { get; set; }
    public List<DateTime> VisitDates { get; set; } = new List<DateTime>();
    public Trainer Trainer { get; set; }
}

class PoolProgram
{
    static void Main()
    {
        var trainer1 = new Trainer { Name = "Смирнов С.С." };
        var trainer2 = new Trainer { Name = "Васильева Е.В." };

        var clients = new List<Client>
        {
            new Client { Name = "Алексей", Trainer = trainer1, VisitDates = new List<DateTime> { new(2024,5,1), new(2024,5,3), new(2024,5,5) } },
            new Client { Name = "Ольга", Trainer = trainer2, VisitDates = new List<DateTime> { new(2024,5,1), new(2024,5,2) } },
            new Client { Name = "Никита", Trainer = trainer1, VisitDates = new List<DateTime> { new(2024,5,2), new(2024,5,4), new(2024,5,6), new(2024,5,7) } }
        };

        while (true)
        {
            Console.WriteLine("\nМЕНЮ БАССЕЙНА:");
            Console.WriteLine("1. Показать клиентов по дате посещения");
            Console.WriteLine("2. Показать клиентов по имени тренера");
            Console.WriteLine("3. Показать даты посещений конкретного клиента");
            Console.WriteLine("4. Найти клиента с наибольшим числом посещений");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите дату (гггг-мм-дд): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime inputDate))
                    {
                        var visitors = clients
                            .Where(c => c.VisitDates.Contains(inputDate))
                            .Select(c => c.Name);

                        if (visitors.Any())
                        {
                            Console.WriteLine($"\nКлиенты, посетившие бассейн {inputDate:yyyy-MM-dd}:");
                            foreach (var name in visitors)
                                Console.WriteLine($"  - {name}");
                        }
                        else
                        {
                            Console.WriteLine("В этот день никто не посещал бассейн.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты.");
                    }
                    break;

                case "2":
                    Console.Write("Введите имя тренера: ");
                    string trainerName = Console.ReadLine();
                    var trainerClients = clients
                        .Where(c => c.Trainer.Name.Equals(trainerName, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (trainerClients.Any())
                    {
                        Console.WriteLine($"\nКлиенты тренера {trainerName}:");
                        foreach (var client in trainerClients)
                            Console.WriteLine($"  - {client.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Нет клиентов с таким тренером.");
                    }
                    break;

                case "3":
                    Console.Write("Введите имя клиента: ");
                    string clientName = Console.ReadLine();
                    var clientFound = clients.FirstOrDefault(c => c.Name.Equals(clientName, StringComparison.OrdinalIgnoreCase));

                    if (clientFound != null && clientFound.VisitDates.Any())
                    {
                        Console.WriteLine($"\nДаты посещения клиента {clientName}:");
                        foreach (var date in clientFound.VisitDates)
                            Console.WriteLine($"  - {date:yyyy-MM-dd}");
                    }
                    else
                    {
                        Console.WriteLine("Клиент не найден или у него нет посещений.");
                    }
                    break;

                case "4":
                    var topClient = clients.OrderByDescending(c => c.VisitDates.Count).FirstOrDefault();
                    if (topClient != null)
                    {
                        Console.WriteLine($"\nКлиент с наибольшим числом посещений:");
                        Console.WriteLine($"  {topClient.Name} — {topClient.VisitDates.Count} посещений");
                    }
                    else
                    {
                        Console.WriteLine("Нет данных о клиентах.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }
}

*/

