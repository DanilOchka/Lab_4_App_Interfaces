using Lab_4_App.model;
using Lab_4_App.repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab_4_App
{
    public partial class MainWindow : Window
    {
        private BookRepository bookRepository = new BookRepository();
        private List<Book> books;

        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            books = bookRepository.GetAllBooks();
            list.ItemsSource = books;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ISBNTextBox.Text) ||
                string.IsNullOrEmpty(NameTextBox.Text) ||
                string.IsNullOrEmpty(AuthorTextBox.Text) ||
                string.IsNullOrEmpty(PublisherTextBox.Text) ||
                !int.TryParse(YearTextBox.Text, out int year))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Book newBook = new Book
            {
                ISBN = ISBNTextBox.Text,
                Name = NameTextBox.Text,
                Author = AuthorTextBox.Text,
                Publisher = PublisherTextBox.Text,
                Year = year
            };

            bookRepository.CreateBook(newBook);
            LoadBooks();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem is Book selectedBook)
            {
                selectedBook.Name = NameTextBox.Text;
                selectedBook.Author = AuthorTextBox.Text;
                selectedBook.Publisher = PublisherTextBox.Text;
                selectedBook.Year = int.TryParse(YearTextBox.Text, out int year) ? year : selectedBook.Year;

                bookRepository.UpdateBook(selectedBook);
                LoadBooks();
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem is Book selectedBook)
            {
                bookRepository.DeleteBook(selectedBook.ISBN);
                LoadBooks();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            ISBNTextBox.Clear();
            NameTextBox.Clear();
            AuthorTextBox.Clear();
            PublisherTextBox.Clear();
            YearTextBox.Clear();
        }


        // Обробник події вибору елемента у ListBox
        private void list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (list.SelectedItem is Book selectedBook)
            {
                // Прив'язка вибраної книги до контексту даних вікна
                this.DataContext = selectedBook;

                // Оновлення списку книг з бази даних
                //LoadBooks();
            }
        }
    }
}
