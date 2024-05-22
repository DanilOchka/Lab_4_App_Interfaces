using System;

namespace Lab_4_App.model
{
    public class Book
    {
        public string ISBN { get; set; } // ISBN книги
        public string Name { get; set; } // Назва книги
        public string Author { get; set; } // Автор книги
        public string Publisher { get; set; } // Видавництво
        public int Year { get; set; } // Рік видання

        // Конструктор без параметрів (за замовчуванням)
        public Book()
        {
        }

        // Конструктор з параметрами для зручного створення об'єктів Book
        public Book(string isbn, string name, string author, string publisher, int year)
        {
            ISBN = isbn;
            Name = name;
            Author = author;
            Publisher = publisher;
            Year = year;
        }
    }
}
