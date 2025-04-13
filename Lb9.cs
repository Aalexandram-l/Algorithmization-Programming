/* Лабораторная работа 9
 * 07.04.2025
 необходимо реализовать обобщенный класс который позволяет хранить в массиве объекты любого типа 
в данном классе необходимо реализовать следующие методы
добавление данных в массив 
удаление из массива (по индексу)
вывод элемента по заданному индексу 
 
 
using System;

class GenericArray<T>
{
    private T[] array;
    private int count;

    public GenericArray(int capacity)
    {
        array = new T[capacity];
        count = 0;
    }

    
    public void Add(T item)
    {
        if (count < array.Length)
        {
            array[count] = item;
            count++;
            Console.WriteLine($"Элемент '{item}' добавлен в массив.");
        }
        else
        {
            Console.WriteLine("Массив полон, невозможно добавить новый элемент.");
        }
    }

    
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < count)
        {
            T removedItem = array[index];
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
            Console.WriteLine($"Элемент '{removedItem}' с индексом {index} удален.");
        }
        else
        {
            Console.WriteLine("Неверный индекс для удаления.");
        }
    }

    public T Get(int index)
    {
        if (index >= 0 && index < count)
        {
            return array[index];
        }
        throw new IndexOutOfRangeException("Указанный индекс выходит за границы массива.");
    }

    public void PrintAt(int index)
    {
        if (index >= 0 && index < count)
        {
            Console.WriteLine($"Элемент с индексом {index}: {array[index]}");
        }
        else
        {
            Console.WriteLine("Неверный индекс.");
        }
    }
}

class Program
{
    static void Main()
    {
        var intArray = new GenericArray<int>(5);
        intArray.Add(10);
        intArray.Add(20);
        intArray.Add(30);
        intArray.PrintAt(1); 
        intArray.RemoveAt(1);
        intArray.PrintAt(1);  

        
        var stringArray = new GenericArray<string>(3);
        stringArray.Add("Hello");
        stringArray.Add("World");
        stringArray.PrintAt(0);  
        stringArray.RemoveAt(0);
        stringArray.PrintAt(0);  
    }
}
*/