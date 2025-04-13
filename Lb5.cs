/* Лабораторная работа 5
10.03.2025

задание 1
класс телефон 
номер телеона и оператор связи
необходимо создать список телефонов и с использованием словаря определить какой оператор наиболее востребован

задание 2
класс две переменные и реализованн метод сложения вычитание умножение и деление
необходима создать два групповых делегата 
первый дел: из операций сложение 2 перемен, вычитание из суммы второй переменной, произведение разности на второй элемент
второй дел: произведение двух элементов, суммирование полученного произведения со вторым элементом, полученная сумма делится на второй элемент


задание 1
using System;
using System.Collections.Generic;

class Phone
{
    public string Number;
    public string Operator;

    public Phone(string number, string operat)
    {
        Number = number;
        Operator = operat;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Вводите номера телефонов и операторов (например: 79123456789 МТС)");
        Console.WriteLine("Для окончания ввода просто нажмите Enter\n");

        var phones = new List<Phone>();

        while (true)
        {
            Console.Write("Введите номер и оператор: ");
            string input = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(input)) break;

            int sInd = input.IndexOf(' ');
            if (sInd > 0)
            {
                string number = input.Substring(0, sInd);
                string operat = input.Substring(sInd + 1);
                phones.Add(new Phone(number, operat));
            }
            else
            {
                Console.WriteLine("Ошибка формата! Нужно ввести номер и оператор через пробел");
            }
        }

        if (phones.Count == 0)
        {
            Console.WriteLine("Вы не ввели ни одного телефона");
            return;
        }

        var opCounts = new Dictionary<string, int>();

        foreach (var phone in phones)
        {
            if (opCounts.ContainsKey(phone.Operator))
                opCounts[phone.Operator]++;
            else
                opCounts[phone.Operator] = 1;
        }

        string popularOperator = "";
        int max = 0;

        foreach (var op in opCounts)
        {
            if (op.Value > max)
            {
                max = op.Value;
                popularOperator = op.Key;
            }
        }

        Console.WriteLine($"\nСамый популярный оператор: {popularOperator}");
    }
}

задание 2
using System;

class TwoVariables
{
    public double A { get; set; }
    public double B { get; set; }

    public TwoVariables(double a, double b)
    {
        A = a;
        B = b;
    }
}

class Program
{
    delegate double BiOper(double a, double b);

    delegate double FirstOper(TwoVariables vars);
    delegate double SecondOper(TwoVariables vars);

    static void Main()
    {
        
        Console.WriteLine("Введите два числа:");
        Console.Write("A = ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("B = ");
        double b = double.Parse(Console.ReadLine());

        var vars = new TwoVariables(a, b);

        BiOper add = (x, y) => x + y;
        BiOper sub = (x, y) => x - y;
        BiOper mul = (x, y) => x * y;
        BiOper div = (x, y) => y != 0 ? x / y : double.NaN;

        FirstOper firstSeq = (x) =>
        {
            double sum = add(x.A, x.B);
            Console.WriteLine($"{x.A} + {x.B} = {sum}");

            double diff = sub(sum, x.B);
            Console.WriteLine($"{sum} - {x.B} = {diff}");

            double result = mul(diff, x.B);
            Console.WriteLine($"{diff} * {x.B} = {result}");
            return result;
        };

        SecondOper secondSeq = (x) =>
        {
            double product = mul(x.A, x.B);
            Console.WriteLine($"{x.A} * {x.B} = {product}");

            double sum = add(product, x.B);
            Console.WriteLine($"{product} + {x.B} = {sum}");

            double result = div(sum, x.B);
            Console.WriteLine($"{sum} / {x.B} = {result}");
            return result;
        };

        Console.WriteLine("\nПервая последовательность операций:");
        firstSeq(vars);

        Console.WriteLine("\nВторая последовательность операций:");
        secondSeq(vars);
        
        
    }
}
*/