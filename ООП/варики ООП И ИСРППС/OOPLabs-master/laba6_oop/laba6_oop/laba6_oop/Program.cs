using System;
using System.Collections.Generic;

namespace laba6_oop
{
    class Author
    {
        List<Book> bookList = new List<Book>();
        string name;

        public Author(string name, List<Book> books)
        {
            this.name = name;
            this.bookList.AddRange(books);
            foreach (var book in books)
            {
                book.ChangeAuthor(this);
            }
            Console.WriteLine("Создан автор {0}, добавлены книги", this.Name);
        }

        public Author(string name, Book book)
        {
            this.name = name;
            this.bookList.Add(book);
            book.ChangeAuthor(this);
            Console.WriteLine("Создан автор {0}, добавлена книга {1}", this.Name, book.Name);
        }

        public Author(string name)
        {
            this.name = name;
            Console.WriteLine("Создан автор {0}", this.Name);
        }

        public void AddBook(Book book)
        {
            this.bookList.Add(book);
        }

        public void PrintBooks()
        {
            foreach (var book in this.bookList)
            {
                Console.Write("{0}  ", book.Name);
            }
            Console.WriteLine();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {

            }
        }

    } // 1

    class Book
    {
        Author author;
        string name;

        public Book(string name, Author author)
        {
            this.author = author;
            author.AddBook(this);
            this.name = name;
            Console.WriteLine("Создана книга {0}, связана с автором {1}", this.Name, author.Name);
        }

        public Book(string name)
        {
            this.name = name;
            Console.WriteLine("Создана книга {0} (без автора)", this.Name);
        }

        public void ChangeAuthor(Author author)
        {
            this.author = author;
            
        }

        public void PrintAuthor()
        {
            Console.WriteLine("{0}", this.author.Name);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {

            }
        }

    } // n

    class Program
    {
        static void Main(string[] args)
        {
            Book CrimeAndPunishment = new Book("Преступление и наказание");
            Author Dostoevskiy = new Author("Достоевский", CrimeAndPunishment);
            Console.WriteLine();

            Dostoevskiy.PrintBooks();
            CrimeAndPunishment.PrintAuthor();
            Console.WriteLine();

            Book Idiot = new Book("Идиот");
            Dostoevskiy.AddBook(Idiot);
            Console.WriteLine();

            Book Besy = new Book("Бесы");
            Besy.ChangeAuthor(Dostoevskiy);
            Console.WriteLine();

            Author Pushkin = new Author("Пушкин");
            Book Onegin = new Book("Евгений Онегин", Pushkin);
            Pushkin.PrintBooks();
            Onegin.PrintAuthor();
            Console.WriteLine();

            Besy.ChangeAuthor(Pushkin);
            Pushkin.PrintBooks();
            Besy.PrintAuthor();

            Console.ReadKey();
        }
    }
}
