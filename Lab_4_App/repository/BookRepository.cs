    using Lab_4_App.model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;

    namespace Lab_4_App.repository
    {
        public class BookRepository
        {
            private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString_ADO"].ConnectionString;

            public List<Book> GetAllBooks()
            {
                List<Book> books = new List<Book>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT ISBN, Name, Author, Publisher, Year FROM Books", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book book = new Book
                        {
                            ISBN = reader.GetString(0).Trim(),
                            Name = reader.GetString(1).Trim(),
                            Author = reader.GetString(2).Trim(),
                            Publisher = reader.GetString(3).Trim(),
                            Year = reader.GetInt32(4)
                        };
                        books.Add(book);
                    }
                }
                return books;
            }

            public void UpdateBook(Book book)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE Books SET Name=@Name, Author=@Author, Publisher=@Publisher, Year=@Year WHERE ISBN=@ISBN", connection);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Name", book.Name);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Publisher", book.Publisher);
                    command.Parameters.AddWithValue("@Year", book.Year);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void CreateBook(Book book)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Books (ISBN, Name, Author, Publisher, Year) VALUES (@ISBN, @Name, @Author, @Publisher, @Year)", connection);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Name", book.Name);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Publisher", book.Publisher);
                    command.Parameters.AddWithValue("@Year", book.Year);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteBook(string isbn)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Books WHERE ISBN=@ISBN", connection);
                    command.Parameters.AddWithValue("@ISBN", isbn);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
