using System;
using System.Collections.Generic;

namespace OOPTask5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool isRun = true;

            while (isRun)
            {
                Console.WriteLine("Библиотека, команды:\n1 - Вывести список книг\n2 - Добавить книгу\n3 - Удалить книгу\n4 - Поиск книг\n5 - Выход\n");
                Console.Write("Введите команду: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        library.ShowBooks();
                        break;
                    case "2":
                        library.AddBook();
                        break;
                    case "3":
                        library.DeleteBook();
                        break;
                    case "4":
                        library.FindBooks();
                        break;
                    case "5":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Не известная команда!");
                        break;
                }

                Console.Write("\nНажмите любую клавишу для продолжения: ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Book
    {
        public int ArticleNumber { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public int YearOfRelease { get; private set; }

        public  Book(string author, string title, int yearOfRelease, int articleNumber)
        {
            Author = author;
            Title = title;
            YearOfRelease = yearOfRelease;
            ArticleNumber = articleNumber;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Книга - {Title} , Автор - {Author} , Год выпуска {YearOfRelease}, Артикул - {ArticleNumber}");
        }
    }

    class Library
    {
        private List <Book> _books;
        private int _nextArticleNumber;

        public Library()
        {
            _nextArticleNumber = 0;
            _books = new List <Book> ();
            _books.Add(new Book("Мюллер", "C# для чайников", 2019, ++_nextArticleNumber));
            _books.Add(new Book("Прайс", "C# 7 и .NET Core. Кросс-платформенная разработка для профессионалов", 2018, ++_nextArticleNumber));
            _books.Add(new Book("Бонд", "Unity и C#. Геймдев от идеи до реализации", 2019, ++_nextArticleNumber));
            _books.Add(new Book("Скит", "C# для профессионалов. Тонкости программирования", 2019, ++_nextArticleNumber));
            _books.Add(new Book("Хокинг", "Unity в действии. Мультиплатформенная разработка на C#", 2017, ++_nextArticleNumber));
        }

        public void AddBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();

            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();

            Console.Write("Введите год выхода книги: ");
            int yearOfRelease = GetNuberFromUser();

            _books.Add(new Book(author, title, yearOfRelease, ++_nextArticleNumber));
            Console.WriteLine("Книга добавлена");
        }

        public void DeleteBook()
        {
            Console.Write("Введите артикульный номер книги которую нужно удалить: ");

            int articleNumber = GetNuberFromUser();

            foreach (var book in _books)
            {
                if (book.ArticleNumber == articleNumber)
                {
                    _books.Remove(book);
                    Console.WriteLine("Книга удалена");
                    return;
                }
            }

            Console.WriteLine("Нет книги с таким номером!");
        }

        public void ShowBooks()
        {
            foreach (var book in _books)
            {
                book.ShowInfo();
            }
        }

        public void ShowBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                book.ShowInfo();
            }
        }

        public void FindBooks()
        {
            List<Book> findBooks = new List<Book>();
            string userInput;

            Console.Write("Укажите автора, или название, или год выхода книги: ");
            userInput = Console.ReadLine();

            findBooks = FindByAuthor(userInput);

            if (findBooks.Count > 0)
            {
                Console.WriteLine("Найденные книги:");
                ShowBooks(findBooks);
                return;
            }

            findBooks = FindByTitle(userInput);

            if (findBooks.Count > 0)
            {
                Console.WriteLine("Найденные книги:");
                ShowBooks(findBooks);
                return;
            }

            findBooks = FindByYearOfRelease(userInput);

            if (findBooks.Count > 0)
            {
                Console.WriteLine("Найденные книги:");
                ShowBooks(findBooks);
                return;
            }

            Console.WriteLine("Книги не найдены:");
        }

        private List<Book> FindByAuthor(string author)
        {
            List<Book> findBooks = new List<Book>();

            foreach (var book in _books)
            {
                if (book.Author.ToLower() == author.ToLower())
                {
                    findBooks.Add(book);  
                }
            }

            return findBooks;
        }

        private List<Book> FindByTitle(string title)
        {
            List<Book> findBooks = new List<Book>();

            foreach (var book in _books)
            {
                if (book.Title.ToLower() == title.ToLower())
                {
                    findBooks.Add(book);
                }
            }

            return findBooks;
        }

        private List<Book> FindByYearOfRelease(string userInput)
        {
            List<Book> findBooks = new List<Book>();
            int yearOfRelease = GetNuberFromUser(userInput);

            foreach (var book in _books)
            {
                if (book.YearOfRelease == yearOfRelease)
                {
                    findBooks.Add(book);
                }
            }

            return findBooks;
        }

        private int GetNuberFromUser()
        {
            int yearOfRelease;

            if (int.TryParse(Console.ReadLine(), out yearOfRelease) == false)
            {
                Console.WriteLine("Не корректное значение!");
            }

            return yearOfRelease;
        }

        private int GetNuberFromUser(string userInput)
        {
            int yearOfRelease;

            if (int.TryParse(userInput, out yearOfRelease) == false)
            {
                Console.WriteLine("Не корректное значение!");
            }

            return yearOfRelease;
        }
    }
}
