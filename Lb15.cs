/*Лабораторная работа 15
19.05.2025
работа с небезопасным кодом
необходимо выделить память под массив из целых элементов
найти в массиве все элементы, которые являются полиндромами
в качестве массива использовать указатель, который хранит адрес, по которому расположены элементы массива 

using System;

class Program
{
    unsafe static void Main()
    {
        int length = 10;

        int* arr = (int*)System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int) * length);

        try
        {
            int[] sampleData = { 121, 123, 454, 567, 22, 78987, 101, 345, 11, 2002 };
            for (int i = 0; i < length; i++)
            {
                arr[i] = sampleData[i];
            }

            Console.WriteLine("Исходный массив:");
            PrintArray(arr, length, 0);
            Console.WriteLine("\nПалиндромы в массиве:");
            PrintPalindromes(arr, length, 0);
        }
        finally
        {
            System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)arr);
        }
    }

    unsafe static void PrintArray(int* arr, int length, int index)
    {
        if (index >= length)
            return;

        Console.Write(arr[index] + " ");
        PrintArray(arr, length, index + 1);
    }

    unsafe static void PrintPalindromes(int* arr, int length, int index)
    {
        if (index >= length)
            return;

        if (IsPalindrome(arr[index]))
            Console.WriteLine(arr[index]);

        PrintPalindromes(arr, length, index + 1);
    }

    static bool IsPalindrome(int number)
    {
        if (number < 0) return false;

        int original = number;
        int reversed = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        return original == reversed;
    }
}
*/