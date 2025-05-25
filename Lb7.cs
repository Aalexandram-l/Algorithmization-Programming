/*
Лабораторная работа 7
24.03.2025
задание 1
события, делегаты
есть класс точка двумя координатами х,у
есть поле заданное 4 точками , начальная точка, которая является объектом класса, лежит в поле
необходимо обработать наступление события выхода точки за пределы области в результате смены координаты на случайное значение 
задание 2
старт прямая, на которой не менеее трех движущихся объектов
задан интервал временной - то, время через которой происходит смена скорости движения объекта (случайным образом)
необходимо обработать события пересечения финиша одним из объектов (финиш задаем сами)

задание 1
using System;

public class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public delegate void OutOf(Point p);
    public event OutOf OutOfBounds;

    private readonly int minX, maxX, minY, maxY;
    private Random rand = new Random();

    public Point(int x, int y, int minX, int maxX, int minY, int maxY)
    {
        X = x;
        Y = y;
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
    }

    public void MoveRandom()
    {
        X += rand.Next(-10, 11);
        Y += rand.Next(-10, 11);

        if (X < minX || X > maxX || Y < minY || Y > maxY)
        {
            OutOfBounds?.Invoke(this);
        }
    }
}
class Program
{
    static void Main()
    {
        Point p = new Point(5, 5, 0, 10, 0, 10);
        p.OutOfBounds += (point) =>
        {
            Console.WriteLine($"Точка вышла за границы: X={point.X}, Y={point.Y}");
        };

        for (int i = 0; i < 20; i++)
        {
            p.MoveRandom();
        }
    }
}

задание 2
using System;
using System.Collections.Generic;
using System.Threading;

public class MovingOb
{
    public string Name { get; }
    public double Position { get; private set; }
    public double Speed { get; private set; }

    private Random rand = new Random();
    private readonly double finish;

    public delegate void Finish(MovingOb obj);
    public event Finish OnFinish;

    public MovingOb(string name, double finish)
    {
        Name = name;
        this.finish = finish;
        Position = 0;
        Speed = rand.Next(1, 5); 
    }

    public void Update()
    {
        Speed = rand.Next(1, 5); 
        Position += Speed;

        if (Position >= finish)
        {
            OnFinish?.Invoke(this);
        }
    }
}
class Program
{
    static void Main()
    {
        double finishLine = 10;
        List<MovingOb> objects = new List<MovingOb>
        {
            new MovingOb("A", finishLine),
            new MovingOb("B", finishLine),
            new MovingOb("C", finishLine)
        };

        bool raceOver = false;

        foreach (var obj in objects)
        {
            obj.OnFinish += (o) =>
            {
                if (!raceOver)
                {
                    raceOver = true;
                    Console.WriteLine($"Объект {o.Name} пересёк финиш первым! Позиция: {o.Position}");
                }
            };
        }

        while (!raceOver)
        {
            foreach (var obj in objects)
            {
                obj.Update();
                Console.WriteLine($"{obj.Name}: позиция = {obj.Position}, скорость = {obj.Speed}");
                if (raceOver) break;
            }
            Thread.Sleep(1000);
        }
    }
}
*/