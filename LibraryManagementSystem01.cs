namespace LibraryManagementSystem01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book (1, "Physics", "Newtorn");
            Book book2 = new Book (2, "Chemistr", "JJ Thomsan");
            Book book3 = new Book (3, "Mathematics", "Al Khwarizmi");
            Book book4 = new Book (4, "Biology", "Abu Al Qasim");
            Book book5 = new Book (5, "Economics", "Jeff Bezos");
            Book book6 = new Book (6, "English", "William Shakespear");
            Library library = new Library { LibraryId = 1, LibraryName = "CureMD" };
            library.add_book(book1);
            library.add_book(book2);
            library.add_book(book3);
            library.add_book(book4);
            library.add_book(book5);
            library.add_book(book6);
            Console.Clear();


            Console.WriteLine("Welcome to Library Management System");
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. View Books List");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        int id;
                        string title, author;
                        Console.Write("Enter the book id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the title of book: ");
                        title = Console.ReadLine();
                        Console.Write("Type the author name: ");
                        author = Console.ReadLine();
                        Book newBook = new Book (id, title, author);
                        library.add_book(newBook);
                        break;
                    case "2":
                        Console.Write("Enter the book id to remove: ");
                        library.remove_book(Convert.ToInt32(Console.ReadLine()));
                        break ;
                    case "3":
                        Console.WriteLine("List of books");
                        library.view_books();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the system");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a number from 1 to 4");
                        break;
                }
            }

            Console.Clear();

            Console.WriteLine("Info of All books");
            book1.display_info();
            book2.display_info();
            book3.display_info();
            book4.display_info();
            book5.display_info();
            book6.display_info();

        }

        // Book Class
        class Book
        {
            public int BookId { get; set; }
            public string Title {  get; set; }
            public string Author { get; set; }

            public Book(int bookId, string title, string author)
            {
                BookId = bookId;
                Title = title;
                Author = author;
            }

            public void display_info()
            {
                Console.WriteLine($"Book id: \"{BookId}\" Title: \"{Title}\" Author: \"{Author}\"");
            }
        }

        class Person
        {
            public int PersonId { get; set; }
            public string PersonName { get; set; }
            public int Age { get; set; }

            public Person(int id, string name, int age)
            {
                PersonId = id;
                PersonName = name;
                Age = age;
            }
        }

        class Library
        {
            public int LibraryId { get; set; }
            public string LibraryName { get; set; }
            public List<Book> LibraryBooks { get; set; }

            public Library()
            { 
                LibraryBooks = new List<Book>();
            }

            public void add_book(Book book)
            {
                bool isBookAlreadyExists = false;
                foreach (Book b in LibraryBooks) 
                {
                    if(b.BookId == book.BookId)
                    {
                        Console.WriteLine("Book with this id already exsits\nTry with another id");
                        isBookAlreadyExists = true;
                        break; 
                    }
                }
                if (!isBookAlreadyExists)
                {
                    LibraryBooks.Add(book);
                    Console.WriteLine($"{book.Title} added successfully");
                }
            }

            public void remove_book(int id)
            {
                bool found = false;
                foreach (Book book in LibraryBooks) 
                { 
                    if(id == book.BookId)
                    {
                        LibraryBooks.Remove(book);
                        Console.WriteLine($"{book.Title} removed successfully");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"Book not found");
                }
            }

            public void view_books()
            {
                int num = 1;
                foreach(Book book in LibraryBooks)
                {
                    Console.WriteLine($"{num} ---> {book.Title}");
                    num++;
                }
            }
        }
    }
}
