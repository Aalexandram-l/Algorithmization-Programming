/*Лабораторная работа 6
 * 17.03.2025
 * 
 * класс машин 
 * характеристика ка
 * год выпуска
 * марка
 * булевская перемнная, которая говорит чистая машина или нет
 * класс гараж
 * содержит все машины
 * класс мойка
 * метод помывки машины
 * с помощью делегата необходимо реализовать помывку каждой машины, если она грязная
 * если чистая выдать, что не требует помывки
using System;
using System.Collections.Generic;

public class Car
{
    public int Year { get; set; }
    public string Brand { get; set; }
    public bool IsDirty { get; set; }

    public Car(int year, string brand, bool isDirty)
    {
        Year = year;
        Brand = brand;
        IsDirty = isDirty;
    }

    public override string ToString()
    {
        return $"{Brand} ({Year}) - " + (IsDirty ? "Грязная" : "Чистая");
    }
}

public class Garage
{
    public List<Car> Cars { get; set; }

    public Garage()
    {
        Cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }
}

public class CarWash
{
    public delegate void WashCarDelegate(Car car);

    public void WashCar(Car car)
    {
        if (car.IsDirty)
        {
            car.IsDirty = false; 
            Console.WriteLine($"Машина {car.Brand} ({car.Year}) помыта.");
        }
        else
        {
            Console.WriteLine($"Машина {car.Brand} ({car.Year}) чистая, мыть не надо.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Garage garage = new Garage();
        CarWash carWash = new CarWash();
        CarWash.WashCarDelegate washDelegate = carWash.WashCar;

        Console.WriteLine("Введите количество машин:");
        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            Console.WriteLine($"Введите данные для машины {i + 1}:");

            Console.Write("Год выпуска: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Марка: ");
            string brand = Console.ReadLine();

            Console.Write("Грязная (да/нет): ");
            bool isDirty = Console.ReadLine().Trim().ToLower() == "да";

            garage.AddCar(new Car(year, brand, isDirty));
        }

        foreach (var car in garage.Cars)
        {
            washDelegate(car);
        }
    }

}

 */