/*
 * Лабораторная работа 13
05.05.2025
имеетя база данных движения товаров на складе, котора хранит сведения о товарах(1 класс), сведения о поставщиках(2 класс), отображение движения товаров(3 класс)
связь по номеру поставщика и номеру товаров

база данных отображение движения товаров
отображает поступил товар или товар выдан
дата поступления или выдачи
(если товар выдоется поле поставщика пустое)
кол-во поступившего товара кол-во выданного 
цена поступления и цена выдачи 

задачи на базе
выдать поступление товаров по дате 
поступление товаров  по поставщику (сгруппированные по поставщику) и отсортированные по дате 
выдать список товаров которые имеются на складе 
выдать список товаров сгруппированных по выдачи (внутри сортировка по дате)
выдать на какую сумму был выдан товар (общая сумма)
прибыль которую получили на складе 

выполнить с использованием библиотеки линк 



using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Movement
{
    public int ProductId { get; set; }
    public int? SupplierId { get; set; }  
    public DateTime Date { get; set; }
    public int KolTovIn { get; set; }  
    public int KolTovOut { get; set; } 
    public decimal PriceIn { get; set; } 
    public decimal PriceOut { get; set; }
}

class Program
{
    static void Main()
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Товар A" },
            new Product { Id = 2, Name = "Товар B" },
            new Product { Id = 3, Name = "Товар C" }
        };

        var suppliers = new List<Supplier>
        {
            new Supplier { Id = 1, Name = "Поставщик X" },
            new Supplier { Id = 2, Name = "Поставщик Y" }
        };

        var movements = new List<Movement>
        {
            new Movement { ProductId = 1, SupplierId = 1, Date = new DateTime(2023, 4, 10), KolTovIn = 100, KolTovOut = 0, PriceIn = 10, PriceOut = 0 },
            new Movement { ProductId = 1, SupplierId = null, Date = new DateTime(2023, 4, 15), KolTovIn = 0, KolTovOut = 20, PriceIn = 0, PriceOut = 15 },
            new Movement { ProductId = 2, SupplierId = 2, Date = new DateTime(2023, 4, 12), KolTovIn = 50, KolTovOut = 0, PriceIn = 20, PriceOut = 0 },
            new Movement { ProductId = 3, SupplierId = 1, Date = new DateTime(2023, 4, 10), KolTovIn = 30, KolTovOut= 0, PriceIn = 15, PriceOut = 0 },
            new Movement { ProductId = 3, SupplierId = null, Date = new DateTime(2023, 4, 18), KolTovIn = 0, KolTovOut = 10, PriceIn = 0, PriceOut = 20 }
        };

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Поступление товаров по дате");
            Console.WriteLine("2. Поступление товаров по поставщику (по введённому поставщику)");
            Console.WriteLine("3. Список товаров на складе");
            Console.WriteLine("4. Список товаров, сгруппированных по выдаче");
            Console.WriteLine("5. Общая сумма выданного товара");
            Console.WriteLine("6. Прибыль склада");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите дату (например, 2023-04-10): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime filterDate))
                    {
                        var incomingByDate = movements
                            .Where(m => m.KolTovIn > 0 && m.Date.Date == filterDate.Date)
                            .Join(products, m => m.ProductId, p => p.Id, (m, p) => new
                            {
                                p.Name,
                                m.KolTovIn,
                                m.Date,
                                SupplierName = suppliers.FirstOrDefault(s => s.Id == m.SupplierId)?.Name
                            });

                        Console.WriteLine($"\nПоступление товаров по дате {filterDate:d}:");
                        foreach (var item in incomingByDate)
                            Console.WriteLine($"{item.Date:d} - {item.Name} - Кол-во: {item.KolTovIn} - Поставщик: {item.SupplierName}");
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты.");
                    }
                    break;

                case "2":
                    Console.Write("Введите имя поставщика: ");
                    string supplierInput = Console.ReadLine();

                    var supplier = suppliers.FirstOrDefault(s => s.Name.Equals(supplierInput, StringComparison.OrdinalIgnoreCase));

                    if (supplier == null)
                    {
                        Console.WriteLine($"Поставщик с именем '{supplierInput}' не найден.");
                        break;
                    }

                    var incomingForSupplier = movements
                        .Where(m => m.KolTovIn > 0 && m.SupplierId == supplier.Id)
                        .OrderBy(m => m.Date)
                        .Join(products, m => m.ProductId, p => p.Id, (m, p) => new
                        {
                            m.Date,
                            ProductName = p.Name,
                            m.KolTovIn
                        });

                    Console.WriteLine($"\nПоступление товаров по поставщику '{supplier.Name}':");
                    foreach (var item in incomingForSupplier)
                    {
                        Console.WriteLine($"{item.Date:d} - {item.ProductName} - Кол-во: {item.KolTovIn}");
                    }
                    break;

                case "3":
                    var stock = products.Select(p =>
                    {
                        int totalIn = movements.Where(m => m.ProductId == p.Id).Sum(m => m.KolTovIn);
                        int totalOut = movements.Where(m => m.ProductId == p.Id).Sum(m => m.KolTovOut);
                        int balance = totalIn - totalOut;
                        return new { p.Name, Balance = balance };
                    }).Where(x => x.Balance > 0);

                    Console.WriteLine("\nТовары на складе:");
                    foreach (var item in stock)
                    {
                        Console.WriteLine($"{item.Name} - Остаток: {item.Balance}");
                    }
                    break;

                case "4":
                    var issuedGrouped = movements
                        .Where(m => m.KolTovOut > 0)
                        .GroupBy(m => m.ProductId);

                    Console.WriteLine("\nВыданные товары сгруппированные по товару:");
                    foreach (var group in issuedGrouped)
                    {
                        string productName = products.FirstOrDefault(p => p.Id == group.Key)?.Name;
                        Console.WriteLine($"Товар: {productName}");
                        foreach (var m in group.OrderBy(m => m.Date))
                        {
                            Console.WriteLine($"  {m.Date:d} - Кол-во выдано: {m.KolTovOut} - Цена выдачи за шт.: {m.PriceOut}");
                        }
                    }
                    break;

                case "5":
                    decimal totalIssuedSum = movements.Sum(m => m.KolTovOut * m.PriceOut);
                    Console.WriteLine($"\nОбщая сумма выданного товара: {totalIssuedSum}");
                    break;

                case "6":
                    decimal totalIncome = movements.Sum(m => m.KolTovIn * m.PriceIn);
                    decimal totalOutcome = movements.Sum(m => m.KolTovOut * m.PriceOut);
                    decimal profit = totalOutcome - totalIncome;
                    Console.WriteLine($"\nПрибыль на складе: {profit}");
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