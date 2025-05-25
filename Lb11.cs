/*Лабороторная работа 11
21.04.2025
дан входной файл состоящий из набора строк 
необходимо создать выходной файл в который поместить строки из входного файла, в которых имеется хотябы одно четное число
число считаем поледовательность цифр ограниченных другими иными знаками 


using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        try
        {

            string[] lines = File.ReadAllLines(inputFile);

            var resultLines = new System.Collections.Generic.List<string>();

            Regex numberRegex = new Regex(@"-?\d+");

            foreach (string line in lines)
            {
                MatchCollection matches = numberRegex.Matches(line);

                foreach (Match match in matches)
                {
                    if (int.TryParse(match.Value, out int number))
                    {
                        if (number % 2 == 0)
                        {
                            resultLines.Add(line);
                            break; 
                        }
                    }
                }
            }

            File.WriteAllLines(outputFile, resultLines);

            Console.WriteLine($"Обработка завершена. Результат записан в {outputFile}");
            Console.WriteLine($"Найдено строк с четными числами: {resultLines.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
*/