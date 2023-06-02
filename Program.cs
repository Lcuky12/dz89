using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp94
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandDeleteBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandFindBookByTitle = "4";
            const string CommandFindBookByAuthor = "5";
            const string CommandBookByReleaseYear = "6";
            const string CommandExitProgramm = "7";

            string userInput;
            bool isOpen = true;

            Storage storage = new Storage();

            while (isOpen)
            {
                Console.WriteLine("Добро пожаловать в хранилище книг");

                storage.ShowAllBooks();

                Console.WriteLine($"{CommandAddBook} - добавить книгу");
                Console.WriteLine($"{CommandDeleteBook} - удалить книгу по названию книги");
                Console.WriteLine($"{CommandShowAllBooks} - показать все книги");
                Console.WriteLine($"{CommandFindBookByTitle} - найти книгу по ее названию");
                Console.WriteLine($"{CommandFindBookByAuthor} - найти книгу по автору");
                Console.WriteLine($"{CommandBookByReleaseYear} - найти книгу по году выпуска");
                Console.WriteLine($"{CommandExitProgramm} - выход из программы\nВыберите нужную команду");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        storage.AddBooks();
                        break;
                    case CommandDeleteBook:
                        storage.DeleteBooks();
                        break;
                    case CommandShowAllBooks:
                        storage.ShowAllBooks();
                        break;
                    case CommandFindBookByTitle:
                        storage.ShowBooksByTitle();
                        break;
                    case CommandFindBookByAuthor:
                        storage.ShowBookByAuthor();
                        break;
                    case CommandBookByReleaseYear:
                        storage.ShowBookByReleaseYear();
                        break;
                    case CommandExitProgramm:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка выбора меню. Выберите подходящие");
                        Console.ReadKey();
                        break;
                }
            }

            Console.Clear();
        }
    }

    class Storage
    {
        private List<Books> _books = new List<Books>();

        public void ShowAllBooks()
        {
            for(int i = 0; i<_books.Count; i++)
            {
                _books[i].ShowBooks();
            }
        }

        public void AddBooks()
        {
            Console.Write("Пропишите название книги ");
            string bookTitle = Console.ReadLine();
            Console.Write("Пропишите автора книги ");
            string author = Console.ReadLine();
            int yearOfIssue = GetNumber("Введите год выпуска ");

            _books.Add(new Books(bookTitle, author, yearOfIssue));
        }

        public int GetNumber(string text)
        {
            Console.Write(text);
            int.TryParse(Console.ReadLine(), out int number);
            return number;
        }

        public void DeleteBooks()
        {
            Console.Write("Пропишите название книги ");
            string bookTitle = Console.ReadLine();
            bool deleteBook = false;

            for (int i = 0; i<_books.Count; i++)
            {
                if (_books[i].GetBookTitle() == bookTitle)
                {
                    Books books = _books[i];
                    _books.Remove(books);
                    deleteBook = true;
                    break;
                }
            }
        }

        public void ShowBooksByTitle()
        {
            Console.Write("Пропишите название книги ");
            string bookTitle = Console.ReadLine();

            for (int i = 0; i<_books.Count; i++)
            {
                if (_books[i].GetBookTitle() == bookTitle) 
                {
                    ShowAllBooks();
                }
                else
                {
                    Console.WriteLine("Ввели неверного автора. Повторите попытку ");
                    Console.ReadKey();
                }
            }
        }

        public void ShowBookByAuthor()
        {
            Console.Write("Пропишите автора книги ");
            string author = Console.ReadLine();

            for(int i = 0; i<_books.Count; i++)
            {
                if (_books[i].GetBookAuthor() == author)
                {
                    ShowAllBooks();
                }
                else
                {
                    Console.WriteLine("Ввели неверного автора.Повторите попытку ");
                }
            }
        }

        public void ShowBookByReleaseYear()
        {
            int yearOfIssue = GetNumber("Введите год выпуска ");

            for(int i = 0; i<_books.Count; i++)
            {
                if (_books[i].GetYearOfIssue() == yearOfIssue)
                {
                    ShowAllBooks();
                }
                else
                {
                    Console.WriteLine("Ввели неверный год выпуска.Повторите попытку ");
                    Console.ReadKey();
                }
            }
        }

    }

    class Books
    {
        private string _bookTitle;
        private string _author;
        private int _yearOfIssue;

        public Books(string bookTitle, string author, int yearOfIssue)
        {
            _bookTitle = bookTitle;
            _author = author;
            _yearOfIssue = yearOfIssue;
        }

        public void ShowBooks()
        {
            Console.WriteLine($"Название - {_bookTitle}, автор - {_author}, год выпуска {_yearOfIssue}");
        }

        public string GetBookTitle()
        {
            return _bookTitle;
        }

        public string GetBookAuthor()
        {
            return _author;
        }

        public int GetYearOfIssue()
        {
            return _yearOfIssue;
        }
    }
}
