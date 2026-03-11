using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        const string CommandAddBook = "1";
        const string CommandRemoveBook = "2";
        const string CommandFindBooks = "3";
        const string CommandPrintAllBooks = "4";
        const string CommandExit = "5";

        Library library = new Library();

        string selectedCommand;

        var isRunning = true;
        
        while (isRunning)
        {
            Console.Write(
                "Добавить книгу - {0}\nУдалить книгу - {1}\nНайти книгу - {2}\nВывести все книги - {3}\nВыход - {4}\n\n{5}\nВвод: ",
                CommandAddBook, CommandRemoveBook, CommandFindBooks, CommandPrintAllBooks, CommandExit, new string('=', 10) );
            selectedCommand = Console.ReadLine();

            switch (selectedCommand)
            {
                case CommandAddBook:
                    library.AddBook();
                    break;
                case CommandRemoveBook:
                    library.RemoveBook();
                    break;
                case CommandFindBooks:
                    library.FindMenu();
                    break;
                case CommandPrintAllBooks:
                    library.PrintAllBooks();
                    break;
                case CommandExit:
                    isRunning = false;
                    break;
                default:
                    Library.ShowIncorrectInputMessage();
                    break;
            }
        }
    }
}

public class Library
{
    private const string InputAuthor = "Автор";
    private const string InputTitle = "Название";
    private const string InputYearWriting = "Год написания";
    private const string InputNumber = "Номер";

    private Dictionary<int, Book> _books;

    private enum SearchType
    {
        Author,
        Title,
        Year
    }
    
    public Library()
    {
        _books = new Dictionary<int, Book>();
    }
    
    public void AddBook()
    {
        Book temporaryBook = new Book(UserInput(InputAuthor),
            UserInput(InputTitle),
            UserInput(InputYearWriting));

        _books.Add(temporaryBook.Number, temporaryBook);

        Console.WriteLine("Книга добавлена.");
        
        WaitForKey();
    }

    public void RemoveBook()
    {
        string userInput;

        userInput = UserInput(InputNumber);

        if (int.TryParse(userInput, out int index))
        {
            if (_books.Remove(index))
                Console.WriteLine("Книга удалена.");
            else
                Console.WriteLine("Книга с таким индексом не найдена.");
        }
        else
        {
            ShowIncorrectInputMessage();
        }
        
        WaitForKey();
    }

    public void FindMenu()
    {
        const string CommandFindByAuthor = "1";
        const string CommandFindByTitle = "2";
        const string CommandFindByYearWriting = "3";
        const string CommandBack = "4";

        string selectedCommand;

        var isWork = true;
        
        Console.Clear();

        while (isWork)
        {
            Console.Write(
                "Поиск по Автору - {0}\nПоиск по Названию - {1}\nПоиск по году написания - {2}\nНазад - {3}\n\n{4}\nВвод: ",
                CommandFindByAuthor, CommandFindByTitle, CommandFindByYearWriting, CommandBack, new string('=',10));
            selectedCommand = Console.ReadLine();

            switch (selectedCommand)
            {
                case CommandFindByAuthor:
                    FindBooks(SearchType.Author);
                    break;
                case CommandFindByTitle:
                    FindBooks(SearchType.Title);
                    break;
                case CommandFindByYearWriting:
                    FindBooks(SearchType.Year);
                    break;
                case CommandBack:
                    isWork = false;
                    break;
                default:
                    ShowIncorrectInputMessage();
                    break;
            }
        }
        
        Console.Clear();
    }
    
    public void PrintAllBooks()
    {
        Print(_books.Values);
    }
    
    public static void ShowIncorrectInputMessage()
    {
        Console.Clear();
        
        Console.WriteLine("\nВвод некорректен!!");
        
        WaitForKey();
    }

    private void FindBooks(SearchType searchType)
    {
        List<Book> result = new List<Book>();

        switch (searchType)
        {
            case SearchType.Author:
                FindByAuthor(ref result);
                break;
            case SearchType.Title:
                FindByTitle(ref result);
                break;
            case SearchType.Year:
                FindByYearWriting(ref result);
                break;
        }

        Print(result);
    }

    private void FindByAuthor(ref List<Book> findBooks)
    {
        string authorInput = UserInput(InputAuthor);
        
        foreach (var book in _books.Values)
        {
            if (book.Author == authorInput)
                findBooks.Add(book);
        }
    }

    private void FindByTitle(ref List<Book> findBooks)
    {
        string titleInput = UserInput(InputTitle);
        
        foreach (var book in _books.Values)
        {
            if (book.Title == titleInput)
                findBooks.Add(book);
        }
    }

    private void FindByYearWriting(ref List<Book> findBooks)
    {
        string yearInput = UserInput(InputYearWriting);
        
        foreach (var book in _books.Values)
        {
            if (book.YearWriting == yearInput)
                findBooks.Add(book);
        }
    }

    private bool EmptinessTest(IEnumerable<Book> books)
    {
        if (books.Any())
        {
            Console.WriteLine("Пусто");
            return false;
        }

        return true;
    }
    
    private void Print(IEnumerable<Book> printBooks)
    {
        Console.Clear();

        if (EmptinessTest(printBooks))
            foreach (var book in printBooks)
                Console.WriteLine(book.ToString());
        
        WaitForKey();
    }
    
    private static void WaitForKey()
   {
       string line = new string('=', 35);
       
        Console.WriteLine($"\n\n{line}\n    Нажмите любую клавишу...\n{line}");
        
        Console.ReadKey(true);
        
        Console.Clear();
    }
    
    private static string UserInput(string inputValue)
    {
        Console.Clear();

        Console.Write($"{inputValue}книги: ");

        return Console.ReadLine();
    }

}

public class Book
{
    private static int s_number = 0;

    public int Number { get; }
    public string Title { get; }
    public string Author { get; }
    public string YearWriting { get; }

    public Book(string author, string title, string yearWriting)
    {
        s_number++;
        Number = s_number;
        Title = title;
        Author = author;
        YearWriting = yearWriting;
    }

    public override string ToString()
    {
        return $"#{Number}|Название: {Title} | Автор: {Author} | Год написания: {YearWriting}";
    }
}