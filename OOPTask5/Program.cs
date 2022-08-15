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

        public Book(string author, string title, int yearOfRelease, int articleNumber)
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
        private List<Book> _books;
        private int _nextArticleNumber;

        public Library()
        {
            _nextArticleNumber = 0;
            _books = new List<Book>();
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
            int yearOfRelease = GetNuber();

            _books.Add(new Book(author, title, yearOfRelease, ++_nextArticleNumber));
            Console.WriteLine("Книга добавлена");
        }

        public void DeleteBook()
        {
            Console.Write("Введите артикульный номер книги которую нужно удалить: ");

            int articleNumber = GetNuber();

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

        public void FindBooks()
        {
            Console.Write("Укажите критерий для поиска :\n1 - по автору\n2 - по названию\n3 - по год выхода книги:");

            switch (GetNuber())
            {
                case 1:
                    FindByAuthor();
                    break;
                case 2:
                    FindByTitle();
                    break;
                case 3:
                    FindByYearOfRelease();
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    break;
            }
        }

        private void FindByAuthor()
        {
            int counter = 0;

            Console.Write("Введите автора книги:");
            string userInput = Console.ReadLine();

            foreach (var book in _books)
            {
                if (book.Author.ToLower() == userInput.ToLower())
                {
                    book.ShowInfo();
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("Не найдено!");
            }
        }

        private void FindByTitle()
        {
            int counter = 0;

            Console.Write("Введите название книги:");
            string userInput = Console.ReadLine();

            foreach (var book in _books)
            {
                if (book.Title.ToLower() == userInput.ToLower())
                {
                    book.ShowInfo();
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("Не найдено!");
            }

        }

        private void FindByYearOfRelease()
        {
            int counter = 0;

            Console.Write("Введите год релиза книги:");
            int yearOfRelease = GetNuber();

            foreach (var book in _books)
            {
                if (book.YearOfRelease == yearOfRelease)
                {
                    book.ShowInfo();
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("Не найдено!");
            }
        }

        private int GetNuber()
        {
            int number;

            if (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Не корректное значение!");
            }

            return number;
        }

    }
}
