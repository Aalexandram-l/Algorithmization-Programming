/*Лабораторная работа 1
 * 10.02.2025
 список абонентов 
каждый номер 
фио
город 
номер телефона
оператор связи
год 

необходимо поиск по городу, по номеру телефона, по оператору связи, по году подключения
меню
абоненты(список из телефонов, которые подключены)
 


using System;
using System.Collections.Generic;
using System.Linq;

class Telephone
{
    public string Number { get; set; }
    public string Operator { get; set; }
    public int YearOfConnection { get; set; }

    public Telephone(string phoneNumber, string operatorName, int yearOfConnection)
    {
        Number = phoneNumber;
        Operator = operatorName;
        YearOfConnection = yearOfConnection;
    }

    public override string ToString()
    {
        return $"Номер: {Number}, Оператор: {Operator}, Год подключения: {YearOfConnection}";
    }
}

class Persone
{
    public string FullName { get; set; }
    public string City { get; set; }
    public List<Telephone> Phones { get; set; }

    public Persone(string fullName, string city)
    {
        FullName = fullName;
        City = city;
        Phones = new List<Telephone>();
    }

    public void AddPhone(Telephone phone)
    {
        Phones.Add(phone);
    }

    public override string ToString()
    {
        return $"ФИО: {FullName}, Город: {City}, Количество телефонов: {Phones.Count}";
    }
}

class Program
{
    static List<Persone> persones = new List<Persone>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Заполнение информации о абонентах");
            Console.WriteLine("2. Поиск абонента по городу");
            Console.WriteLine("3. Поиск абонента по номеру телефона");
            Console.WriteLine("4. Поиск абонента по оператору связи");
            Console.WriteLine("5. Поиск абонента по году подключения");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FillSubscribers();
                    break;
                case "2":
                    SearchByCity();
                    break;
                case "3":
                    SearchByPhoneNumber();
                    break;
                case "4":
                    SearchByOperator();
                    break;
                case "5":
                    SearchByYearOfConnection();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void FillSubscribers()
    {
        Console.Write("Введите количество абонентов: ");
        int subscriberCount;
        if (int.TryParse(Console.ReadLine(), out subscriberCount) && subscriberCount > 0)
        {
            for (int i = 0; i < subscriberCount; i++)
            {
                Console.WriteLine($"Введите данные для абонента {i + 1}:");

                Console.Write("ФИО: ");
                string fullName = Console.ReadLine();

                Console.Write("Город: ");
                string city = Console.ReadLine();

                Persone subscriber = new Persone(fullName, city);

                Console.Write("Введите количество телефонов: ");
                int phoneCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < phoneCount; j++)
                {
                    Console.WriteLine($"Введите данные для телефона {j + 1}:");

                    Console.Write("Номер телефона: ");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Оператор связи: ");
                    string operatorName = Console.ReadLine();

                    Console.Write("Год подключения: ");
                    int yearOfConnection = int.Parse(Console.ReadLine());

                    Telephone phone = new Telephone(phoneNumber, operatorName, yearOfConnection);
                    subscriber.AddPhone(phone);
                }

                persones.Add(subscriber);
            }
        }
        else
        {
            Console.WriteLine("Ошибка! Введите положительное целое число.");
        }
    }

    static void SearchByCity()
    {
        Console.Write("Введите город, чтобы отфильтровать абонентов: ");
        string city = Console.ReadLine();

        var result = persones.Where(s => s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();

        if (result.Any())
        {
            Console.WriteLine("Абоненты, проживающие в этом городе:");
            foreach (var subscriber in result)
            {
                Console.WriteLine(subscriber);
                foreach (var phone in subscriber.Phones)
                {
                    Console.WriteLine(phone);
                }
            }
        }
        else
        {
            Console.WriteLine("Абонентов из этого города не найдено.");
        }
    }

    static void SearchByPhoneNumber()
    {
        Console.Write("Введите номер телефона для поиска: ");
        string phoneNumber = Console.ReadLine();

        var result = persones
            .Where(s => s.Phones.Any(p => p.Number == phoneNumber))
            .ToList();

        if (result.Any())
        {
            Console.WriteLine("Абоненты с этим номером телефона:");
            foreach (var subscriber in result)
            {
                Console.WriteLine(subscriber);
                foreach (var phone in subscriber.Phones.Where(p => p.Number == phoneNumber))
                {
                    Console.WriteLine(phone);
                }
            }
        }
        else
        {
            Console.WriteLine("Абонента с таким номером телефона не найдено.");
        }
    }

    static void SearchByOperator()
    {
        Console.Write("Введите оператора связи для поиска: ");
        string operatorName = Console.ReadLine();

        var result = persones
            .Where(s => s.Phones.Any(p => p.Operator.Equals(operatorName, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        if (result.Any())
        {
            Console.WriteLine("Абоненты с этим оператором связи:");
            foreach (var subscriber in result)
            {
                Console.WriteLine(subscriber);
                foreach (var phone in subscriber.Phones.Where(p => p.Operator.Equals(operatorName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine(phone);
                }
            }
        }
        else
        {
            Console.WriteLine("Абонентов с этим оператором не найдено.");
        }
    }

    static void SearchByYearOfConnection()
    {
        Console.Write("Введите год подключения для поиска: ");
        int year = int.Parse(Console.ReadLine());

        var result = persones
            .Where(s => s.Phones.Any(p => p.YearOfConnection == year))
            .ToList();

        if (result.Any())
        {
            Console.WriteLine("Абоненты с таким годом подключения:");
            foreach (var subscriber in result)
            {
                Console.WriteLine(subscriber);
                foreach (var phone in subscriber.Phones.Where(p => p.YearOfConnection == year))
                {
                    Console.WriteLine(phone);
                }
            }
        }
        else
        {
            Console.WriteLine("Абонентов с таким годом подключения не найдено.");
        }
    }
}
*/