/*Лабораторная работа 16
 20.05.2025
на вход подается текст, состоящий из нескольких строк.
необходимо создать двумерный массив или массив массивов, где в качестве элементов, 
которые определяют строку будет наименование элемента и количество его повторений. 
у указателя 2 звезды, тип стринг, второй элемент стринг

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = @"apple
banana
apple
orange
banana
apple";

 
        string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> frequency = new Dictionary<string, int>();

        foreach (string line in lines)
        {
            string trimmed = line.Trim();
            if (frequency.ContainsKey(trimmed))
                frequency[trimmed]++;
            else
                frequency[trimmed] = 1;
        }

        string[][] result = new string[frequency.Count][];
        int index = 0;

        foreach (var kvp in frequency)
        {
            result[index] = new string[2]; 
            result[index][0] = kvp.Key;
            result[index][1] = kvp.Value.ToString();
            index++;
        }

        foreach (var pair in result)
        {
            Console.WriteLine($"{pair[0]}: {pair[1]}");
        }
    }
}
*/

