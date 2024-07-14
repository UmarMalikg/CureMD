using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem03
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            Library library = new Library();
            library.Librarian = library.Librarian = new Librarian(1, "John Doe", 30, 1001);

            Console.WriteLine("Welcome to Library Management System");
            bool exit = false;

            while(!exit)
            {
                Console.WriteLine("\n-----------------------MENU-----------------------\n");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. View Books");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List the issued books");
                Console.WriteLine("6. Issue book");
                Console.WriteLine("7. return book");
                Console.WriteLine("8. Add User");
                Console.WriteLine("9. Remove User");
                Console.WriteLine("10. Search User");
                Console.WriteLine("11. View Transaction History");
                Console.WriteLine("12. Exit");
                Console.WriteLine("Select option 1 to 11");

                string choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        //add new book
                        Console.WriteLine("1. For Fiction Book");
                        Console.WriteLine("2. For Non Fiction Book");
                        Console.WriteLine("Selct option 1 or 2");
                        string bookChoice = Console.ReadLine();
                        int id;
                        string title, author;
                        Console.Write("Enter the id of book: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the name of book: ");
                        title = Console.ReadLine();
                        Console.Write("Enter the author's name: ");
                        author = Console.ReadLine();
                        switch (bookChoice)
                        {
                            case "1":
                                //to add fiction book
                                Console.Write("Enter the genere for book: ");
                                string genere = Console.ReadLine();
                                FictionBook fictionBook = new FictionBook(id, title, author, genere);
                                library.Books.Add(fictionBook);
                                break;
                            case "2":
                                //to add non fiction book
                                Console.Write("Enter the subject for book: ");
                                string subject = Console.ReadLine();
                                NonFictionBook nonFictionBook = new NonFictionBook(id, title, author, subject);
                                library.Books.Add(nonFictionBook);
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case "2":
                        //remove book
                        Console.Write("Enter book id: ");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        library.remove_book(Id);
                        break;
                    case "3":
                        //view books
                        library.view_books();
                        break;
                    case "4":
                        //search book
                        Console.Write("Type the title to search for a book: ");
                        string Title = Console.ReadLine();
                        library.search_book(Title);
                        break;
                    case "5":
                        //enlist issued books
                        library.list_issued_book();
                        break;
                    case "6":
                        //issue book
                        Console.Write("Enter the book id: ");
                        int bId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the user id");
                        int uId = Convert.ToInt32(Console.ReadLine());
                        Book issueBook = library.get_book_by_id(bId);
                        Person user = library.get_user_by_id(uId);
                        if (issueBook.IsIssued)
                        {
                            Console.WriteLine("This book was already issued");
                        }
                        else if (issueBook != null)
                        {
                            library.Librarian.issue_book(issueBook, user);
                        }
                        break;
                    case "7":
                        //return book
                        Console.Write("Enter the user id: ");
                        int UID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the book id: ");
                        int BID = Convert.ToInt32(Console.ReadLine());
                        Book returnBook = library.get_book_by_id(BID);
                        Person USER = library.get_user_by_id(UID);
                        if (returnBook == null)
                        {
                            Console.WriteLine("There's no book with this id in the library");
                        }
                        else if (USER == null)
                        {
                            Console.WriteLine("There's no such a user loged in the library");
                        }
                        else if (!USER.isBorrowed)
                        {
                            Console.WriteLine("This user has'nt borrowed any book");
                        }
                        else if (!returnBook.IsIssued)
                        {
                            Console.WriteLine("This Book is not issued to any of the user");
                        }
                        else
                        {
                            library.Librarian.return_book(returnBook, USER);
                        }
                        break;
                    case "8":
                        //add new user
                        Console.Write("Enter user id: ");
                        int Userid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the user name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the age of user: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Person newUser = new Person(Userid, name, age);
                        library.add_user(newUser);
                        break;
                    case "9":
                        //remove user
                        Console.WriteLine("Enter the user id");
                        int USERID = Convert.ToInt32(Console.ReadLine());
                        Person newUSER = library.get_user_by_id(USERID);
                        if (newUSER == null)
                        {
                            Console.WriteLine("There's no such user loged in the library");
                        }
                        else
                        {
                            library.remove_user(USERID);
                        }
                        break;
                    case "10":
                        //searvh user
                        Console.WriteLine("Enter the name of user");
                        string userName = Console.ReadLine();
                        library.search_user(userName);
                        break;
                    case "11":
                        //transaction history
                        Console.WriteLine("Enter the user id whos transaction you wanna sse");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        Person newPerson = library.get_user_by_id(ID);
                        newPerson.transaction_history();
                        break;
                    case "12":
                        //exiting the system
                        Console.WriteLine("Exiting the Library Management System");
                        exit = true;
                        break;
                    default:
                        //invalid choice
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5");
                        break;
                }
            }
        }

        //Book class
        abstract class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsIssued { get; set; }

            //constructor
            protected Book(int id, string title, string author)
            {
                Id = id;
                Title = title;
                Author = author;
                IsIssued = false;
            }
            public abstract void display_info();
        }

        // Fiction Book class
        class FictionBook : Book
        {
            public string Genere { get; set; }
            //constructor
            public FictionBook(int id, string title, string author, string genere): base (id, title, author)
            {
                Genere = genere;
            }

            //display info method
            public override void display_info()
            {
                Console.WriteLine($"ID: \"{Id}\" Title: \"{Title}\" Author: \"{Author}\" Genere: \"{Genere}\" ");
            }
        }

        //Non Fiction Book Class
        class NonFictionBook : Book
        {
            public string Subject { get; set; }

            //constructor
            public NonFictionBook(int id, string title, string author, string subject): base (id, title, author)
            {
                Subject = subject;
            }

            //display info method
            public override void display_info()
            {
                Console.WriteLine($"ID: \"{Id}\" Title: \"{Title}\" Author: \"{Author}\" Subject: \"{Subject}\" ");
            }
        }

        //Person class
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public bool isBorrowed { get; set; }
            public List<String> TransctionHistory { get; set; }

            //constructor
            public Person(int id, string name, int age)
            {
                Id = id;
                Name = name;
                Age = age;
                isBorrowed = false;
                TransctionHistory = new List<String>();
            }

            //transaction history
            public void transaction_history()
            {
                foreach(String history in TransctionHistory)
                {
                    Console.WriteLine(history);
                }
            }
        }

        //Librarian Class
        class Librarian : Person
        {
            public int EmployeeId { get; set; }

            //constructor
            public Librarian(int id, string name, int age, int employeeId): base(id, name, age)
            {
                EmployeeId = employeeId;
            }

            //issue book method
            public void issue_book(Book book, Person user)
            {
                if (book.IsIssued)
                {
                    Console.WriteLine("This book was already issued to someone");
                    return;
                }
                book.IsIssued = true;
                user.isBorrowed = true;
                user.TransctionHistory.Add("Rs.50 deposited");
                Console.WriteLine($"{book.Title} issued to {user.Name}");
            }

            //return book
            public void return_book(Book book, Person user)
            {
                if(!book.IsIssued)
                {
                    Console.WriteLine("This book was not issued");
                    return;
                }
                if (!user.isBorrowed)
                {
                    Console.WriteLine("This user hasn't borrowed any books.");
                    return;
                }
                book.IsIssued = false;
                user.isBorrowed= false;
                user.TransctionHistory.Add("Rs. 40 Recieved");
                Console.WriteLine($"{user.Name} returned {book.Title}");
            }
        }

        //Library class
        class Library
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Book> Books { get; set; }
            public List<Person> Users { get; set; }
            public Librarian Librarian { get; set; }

            //constructor
            public Library()
            {
                Books = new List<Book>();
                Users = new List<Person>();
            }

            // get book by id
            public Book get_book_by_id(int id)
            {
                foreach (Book book in Books)
                {
                    if(book.Id == id) return book;
                }
                return null;
            }

            // add book
            public void add_book(Book book)
            {
                foreach(Book b in Books)
                {
                    if(b.Id == book.Id)
                    {
                        Console.WriteLine("Book with this id already exists");
                        return;
                    }
                    Books.Add(book);
                    Console.WriteLine("Book added successfully");
                }
            }

            //remove book
            public void remove_book(int id)
            {
                foreach( Book book in Books)
                {
                    if(id == book.Id)
                    {
                        Books.Remove(book);
                        Console.WriteLine("Removed Successfully");
                        return;
                    }
                }
                Console.WriteLine("Book not found");
            }

            //view books
            public void view_books()
            {
                int num = 1;
                foreach(Book book in Books)
                {
                    Console.WriteLine($"{num} ---> {book.Title}");
                }
            }

            //search book
            public void search_book(string title)
            {
                foreach(Book book in Books)
                {
                    if(book.Title == title)
                    {
                        book.display_info();
                        return;
                    }
                }
                Console.WriteLine("Book not found");
            }

            //list issued books
            public void list_issued_book()
            {
                bool isAnyBookIssued = false;
                foreach(Book book in Books)
                {
                    int num = 1;
                    if (book.IsIssued)
                    {
                        Console.WriteLine($"{num} --->{book.Title}");
                        isAnyBookIssued = true;
                    }
                }
                if (!isAnyBookIssued)
                {
                    Console.WriteLine("None of the book issued right now");
                }
            }

            //get user by id
            public Person get_user_by_id(int id)
            {
                foreach (Person user in Users)
                {
                    if (user.Id == id)
                    {
                        return user;
                    }
                }
                return null;
            }

            //add user method
            public void add_user(Person user)
            {
                foreach(Person person in Users)
                {
                    //check if the person with same id already exists
                    if(person.Id == user.Id)
                    {
                        Console.WriteLine("User with this id already exsits\nTry with another id");
                        return;
                    }
                }
                //add user to list
                Users.Add(user);
                Console.WriteLine("User added successfully");
            }

            //remove user
            public void remove_user(int id)
            {
                foreach (Person user in Users)
                {
                    //check if user exists and remove
                    if (user.Id == id)
                    {
                        Users.Remove(user);
                        Console.WriteLine("User removed");
                        return;
                    }
                }
                //if user not exists, then display not found prompt
                Console.WriteLine("User not found");
            }

            //search user
            public void search_user(string name)
            {
                foreach (Person user in Users)
                {
                    //if user exists then return
                    if (user.Name == name)
                    {
                        Console.WriteLine($"Person id: {user.Id} | Name: {user.Name} | Age: {user.Age}");
                        return;
                    }
                }
                //if not exists, then display not found prompt
                Console.WriteLine("User not found");
            }

        }
    }
}
