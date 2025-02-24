/*  Лабораторная работа 3
 *  24.02.2025
дана последовательность из чисел, математических знаков и скобок
необходимо определить правильно ли раставлены скобки
с помощью стека
проверять пустоту стека 
открывающая скобка - в стек
если что-то осталось в стеке - неправильная последовательность


using System.Collections.Generic;
class Programma1
{
    static bool IsRightLocation(string sequence)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in sequence)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char staples = stack.Pop();
                if ((ch == ')' && staples != '(') ||
                    (ch == ']' && staples != '[') ||
                    (ch == '}' && staples != '{'))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    static void Main()
    {
        Console.WriteLine("Введите последовательность для проверки:");
        string sequence = Console.ReadLine();
        if (sequence.Length == 0)
        {
            Console.WriteLine("Стек пуст. Попробуйте снова! ");
        }
        else if (IsRightLocation(sequence))
        {
            Console.WriteLine("Поздравляем! Скобки расставлены верно!");
        }
        else
        {
            Console.WriteLine("Неправильное расположение скобок! Попробуйте ещё раз!");
        }
    }
}
*/