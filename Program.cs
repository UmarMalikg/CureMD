using System.ComponentModel.DataAnnotations;

namespace LiabraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.addBook();
            library.addBook();
            library.viewBooks();
            library.removeBook();
            library.viewBooks();
        }

        class Book
        {
            public string title, bookID, author;
            public Book(string bookID, string title, string author)
            {
                this.title = title;
                this.bookID = bookID;
                this.author = author;
            }
            public void displayInfo()
            {
                Console.WriteLine($"Title : {title}");
                Console.WriteLine($"Book ID : {bookID}");
                Console.WriteLine($"Author : {author}");
            }
        };        
        class Library
        {
            private string libraryName, libraryID;
            private List<Book> libraryBooks = new List<Book>();
            public void addBook()
            {
                Console.WriteLine("********\"Add Book\"*******");
                string title, author, id;
                Console.Write("Enter book id: ");
                id = Console.ReadLine();
                Console.Write("Enter book title: ");
                title = Console.ReadLine();
                Console.Write("Enter book author: ");
                author = Console.ReadLine();
                Book book = new Book(id, title, author);
                libraryBooks.Add(book);
            }
            public void removeBook() {
                bool found = false;
                Console.WriteLine("********\"Remove Book\"*******");
                Console.Write("Enter Id");
                string id;
                id = Console.ReadLine();
                foreach (Book book in libraryBooks) { 
                if(id == book.bookID)
                    {
                        libraryBooks.Remove(book);
                        found = true;
                        Console.WriteLine("book remove successfully");
                        break;
                    }
                }

                if (!found) {
                    Console.WriteLine("book not found");
                }

            }
            public void viewBooks()
            {
                foreach (Book book in libraryBooks) { 
                    Console.WriteLine($"{book.title} + {book.bookID}");
                }
            }
        }
    }
}
