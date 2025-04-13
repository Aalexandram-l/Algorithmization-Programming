/*Лабораторная работа 4
 * 03.03.2025
 1. на вход выражение представляющее собой постфиксую польскую запись
необходимо с использованием стека вычислить выражение 
разделение с помощью пробела 
3*5+2
3 5* 2+
5/0 - невозможно
5 0/
 2. на вход список элиментов 
- определить элементы с помощью которых составлен список с хешсетом
- выдать частоту появления каждого элемента с помощью дикшенари

задание 1
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите постфиксное выражение:");
        string input = Console.ReadLine();
        double result = Postfix(input);
        Console.WriteLine("Результат: " + result);

        static double Postfix(string expr)
        {
            var stack = new Stack<double>();
            string[] tokens = expr.Split(' ');

            if (tokens.Length > 0 && IsOpe(tokens[0]))
            {
                Console.WriteLine("Ошибка: первое значение не может быть операцией.");
            }

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double num))
                {
                    stack.Push(num);
                }
                else if (IsOpe(token))
                {
                    if (stack.Count < 2)
                    {
                        Console.WriteLine("Ошибка: недостаточно операндов для операции.");
                    }

                    double b = stack.Pop();
                    double a = stack.Pop();

                    if (token == "+") stack.Push(a + b);
                    if (token == "-") stack.Push(a - b);
                    if (token == "*") stack.Push(a * b);
                    if (token == "/")
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Ошибка: деление на ноль.");
                        }
                        stack.Push(a / b);
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: неизвестный символ.");
                }
            }

            if (stack.Count != 1)
            {
                Console.WriteLine("Ошибка: некорректное количество элементов в стеке.");
            }

            return stack.Pop();
        }

        static bool IsOpe(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }
    }
}
задание 2
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 1, 3 };

        HashSet<int> Numbers = new HashSet<int>(numbers);

        Dictionary<int, int> counts = new Dictionary<int, int>();

        foreach (var num in numbers)
        {
            if (counts.ContainsKey(num))
            {
                counts[num]++;
            }
            else
            {
                counts[num] = 1;
            }
        }

        Console.WriteLine("Уникальные числа:");
        foreach (var num in Numbers)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("\nСколько раз встречается каждое число:");
        foreach (var pair in counts)
        {
            Console.WriteLine($"Число {pair.Key}: {pair.Value} раз(а)");
        }
    }
}
*/