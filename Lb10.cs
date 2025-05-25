/*
Лабораторная работа 10
14.04.2025
база данных библиотека в которой книга описана следующей структурой
фио, наименование, год выпуска, издательство
необходимо сделать выборку, какая книга никогда не выдовалась читателю и какие книги находятся на руках
у каждой книги есть бланк с датами выдачи и сдачи 


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
 
        List<Book> books = new List<Book>
        {
            new Book("Толстой Л.Н.", "Война и мир", 1869, "Эксмо"),
            new Book("Достоевский Ф.М.", "Преступление и наказание", 1866, "АСТ"),
            new Book("Булгаков М.А.", "Мастер и Маргарита", 1966, "Азбука")
        };

        List<BookRecord> records = new List<BookRecord>
        {
            new BookRecord(books[0], new DateTime(2023, 1, 10), new DateTime(2023, 2, 15)),
            new BookRecord(books[0], new DateTime(2023, 3, 1), null), 
            new BookRecord(books[2], new DateTime(2023, 2, 5), new DateTime(2023, 3, 10))
        };

        var neverBorrowed = books.Where(b => !records.Any(r => r.Book == b)).ToList();

        var onHands = records.Where(r => r.RetDate == null).Select(r => r.Book).ToList();

        Console.WriteLine("Никогда не выдавались:");
        foreach (var book in neverBorrowed)
        {
            Console.WriteLine($"{book.Author} - {book.Title}");
        }

        Console.WriteLine("\nСейчас на руках:");
        foreach (var book in onHands)
        {
            Console.WriteLine($"{book.Author} - {book.Title}");
        }
    }
}

class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }

    public Book(string author, string title, int year, string publisher)
    {
        Author = author;
        Title = title;
        Year = year;
        Publisher = publisher;
    }
}

class BookRecord
{
    public Book Book { get; set; }
    public DateTime CheckDate { get; set; }
    public DateTime? RetDate { get; set; }

    public BookRecord(Book book, DateTime checkDate, DateTime? retDate)
    {
        Book = book;
        CheckDate = checkDate;
        RetDate = retDate;
    }
}
*/

