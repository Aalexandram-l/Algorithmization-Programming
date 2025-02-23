/*
Лабораторная работа 2 
17.02.2025

задача на интерфейсы
1 класс: одно поле наименнование
три производных класса:
    1 окружность, поле - радиус
    2 квадрат, поле - длина стороны
    3 равносторон треугольник, поле - длина стороны

интерфейс два метода:
    1 метод поиска периметра
    2 метод поиска площади

каждый класс наследник интерфейса 


using System;
public interface IShape
{
    double GetPerimeter();  
    double GetArea();       
}
public class Shape
{
    public string Name { get; set; } 
    public Shape(string name)
    {
        Name = name;
    }
}
public class Circle : Shape, IShape
{
    public double Radius { get; set; }
    public Circle(string name, double radius) : base(name)
    {
        Radius = radius;
    }
    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
public class Square : Shape, IShape
{
    public double SideLength { get; set; }
    public Square(string name, double sideLength) : base(name)
    {
        SideLength = sideLength;
    }
    public double GetPerimeter()
    {
        return 4 * SideLength;
    }
    public double GetArea()
    {
        return SideLength * SideLength; 
    }
}
public class Triangle : Shape, IShape
{
    public double SideLength { get; set; }
    public Triangle(string name, double sideLength) : base(name)
    {
        SideLength = sideLength;
    }
    public double GetPerimeter()
    {
        return 3 * SideLength; 
    }
    public double GetArea()
    {
        return (Math.Sqrt(3) / 4) * SideLength * SideLength;
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите радиус окружности");
        int r = Convert.ToInt32(Console.ReadLine());
        Circle circle = new Circle("Окружность", r);

        Console.WriteLine("Введите сторону квадрата");
        int a = Convert.ToInt32(Console.ReadLine());
        Square square = new Square("Квадрат", a);

        Console.WriteLine("Введите сторону треугольника");
        int b = Convert.ToInt32(Console.ReadLine());
        Triangle triangle = new Triangle("Треугольник", b);

        Console.WriteLine($"{circle.Name} - Периметр: {circle.GetPerimeter()}, Площадь: {circle.GetArea()}");
        Console.WriteLine($"{square.Name} - Периметр: {square.GetPerimeter()}, Площадь: {square.GetArea()}");
        Console.WriteLine($"{triangle.Name} - Периметр: {triangle.GetPerimeter()}, Площадь: {triangle.GetArea()}");
    }
}
*/