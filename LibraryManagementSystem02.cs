namespace LibraryManagementSystem02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library { LibraryId = 1, LibraryName = "Astonished" };
            library.Librarian = new Librarian(1, "John Doe", 30, 1001);

            Book book1 = new Book(1, "Physics", "Newtorn");
            Book book2 = new Book(2, "Chemistr", "JJ Thomsan");
            Book book3 = new Book(3, "Mathematics", "Al Khwarizmi");
            Book book4 = new Book(4, "Biology", "Abu Al Qasim");
            Book book5 = new Book(5, "Economics", "Jeff Bezos");
            Book book6 = new Book(6, "English", "William Shakespear");

            library.add_book(book1);
            library.add_book(book2);
            library.add_book(book3);
            library.add_book(book4);
            library.add_book(book5);
            library.add_book(book6);

            Console.Clear();


            Console.WriteLine("Welcome to Library Management System");
            bool exit = false;

            //loop for user intraction
            while (!exit)
            {
                //displaying menu
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
                Console.WriteLine("11. Exit");
                Console.WriteLine("Select option 1 to 11");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int id;
                        string title, author;
                        Console.Write("Enter the id of book: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the name of book: ");
                        title = Console.ReadLine();
                        Console.Write("Enter the author's name: ");
                        author = Console.ReadLine();
                        Book newBook = new Book(id, title, author);
                        library.add_book(newBook);
                        break;
                    case "2":
                        Console.Write("Enter book id: ");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        library.remove_book(Id);
                        break;
                    case "3":
                        library.view_books();
                        break;
                    case "4":
                        Console.Write("Type the title to search for a book: ");
                        string Title = Console.ReadLine();
                        library.search_book(Title);
                        break;
                    case "5":
                        library.list_issued_books();
                        break;
                    case "6":
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
                        else if(issueBook != null)
                        {
                            library.Librarian.issue_book(issueBook, user);
                        }
                        break;
                    case "7":
                        Console.Write("Enter the user id: ");
                        int UID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the book id: ");
                        int BID = Convert.ToInt32(Console.ReadLine());
                        Book returnBook = library.get_book_by_id(BID);
                        Person USER = library.get_user_by_id(UID);
                        if(returnBook == null)
                        {
                            Console.WriteLine("There's no book with this id in the library");
                        } 
                        else if(USER == null)
                        {
                            Console.WriteLine("There's no such a user loged in the library");
                        }
                        else if (!USER.IsBorrowed)
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
                        Console.WriteLine("Enter the user id");
                        int USERID = Convert.ToInt32(Console.ReadLine());
                        Person newUSER = library.get_user_by_id(USERID);
                        if(newUSER == null)
                        {
                            Console.WriteLine("There's no such user loged in the library");
                        }
                        else
                        {
                            library.remove_user(USERID);
                        }
                        break;
                    case "10":
                        Console.WriteLine("Enter the name of user");
                        string userName = Console.ReadLine();
                        library.search_user(userName);
                        break;
                    case "11":
                        Console.WriteLine("Exiting the Library Management System");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5");
                        break;
                }
            }

        }

        //book class
        class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsIssued { get; set; }

            //constructor
            public Book(int id, string title, string author)
            {
                BookId = id;
                Title = title;
                Author = author;
                IsIssued = false; //initially isIssued false for all books
            }

            //function to display the information about the book
            public void display_info()
            {
                Console.WriteLine($"Book id: {BookId} <---> Title: {Title} <---> Author {Author}");
            }
        }

        //person class
        class Person
        {
            public int PersonId { get; set; }
            public string PersonName { get; set; }
            public int PersonAge { get; set; }

            public bool IsBorrowed {  get; set; }

            //constructor
            public Person(int id, string name, int age)
            {
                PersonId = id;
                PersonName = name;
                PersonAge = age;
                IsBorrowed = false; //initially, the person borrowed no book
            }
        }


        //librarian class inherits from the Person class
        class Librarian : Person
        {
            public int EmployeeId { get; set; }

            //constructor
            public Librarian(int id, string name, int age, int employeeId): base(id, name, age) //id, name and age inherited from Person class
            {
                EmployeeId = id;
            }

            //function to issue book
            public void issue_book(Book book, Person user)
            {
                //chaging the stsstus of IsIssued and ISBorrowed
                book.IsIssued = true;
                user.IsBorrowed = true;
                Console.WriteLine($"{book.Title} issued to {user.PersonName}");
            }

            //function to return the book
            public void return_book(Book book, Person user)
            {
                //changing the status of isIssued and isBorrowed
                book.IsIssued = false;
                user.IsBorrowed = false;
                Console.WriteLine($"{user.PersonName} returned {book.Title}");
            }
        }


        //library class
        class Library
        {
            public int LibraryId { get; set; }
            public string LibraryName { get; set; }

            //declaring the list of type Book
            public List<Book> LibraryBooks { get; set; }

            //Declaring the list of type Person
            public List<Person> Users { get; set; }

            //Instance for Librarian
            public Librarian Librarian { get; set; }

            //constructor
            public Library()
            {
                //whenever the library object will create the empty book list and user list will also creates
                LibraryBooks = new List<Book>();
                Users = new List<Person>();
            }

            //function to get the user by using id
            public Person get_user_by_id(int id)
            {
                foreach(Person user in Users)
                {
                    if(user.PersonId == id)
                    {
                        return user;
                    }
                }
                return null;
            }

            //function to add new user in the library
            public void add_user(Person user)
            {
                foreach(Person person in Users)
                {
                    //check if the person with same id already exists
                    if(person.PersonId == user.PersonId)
                    {
                        Console.WriteLine("User with this id already exsits\nTry with another id");
                        return;
                    }
                }
                //add user to list
                Users.Add(user);
                Console.WriteLine("User added successfully");
            }

            //function to remove the user from list
            public void remove_user(int id)
            {
                foreach(Person user in Users)
                {
                    //check if user exists and remove
                    if(user.PersonId == id)
                    {
                        Users.Remove(user);
                        Console.WriteLine("User removed");
                        return;
                    }
                }
                //if user not exists, then display not found prompt
                Console.WriteLine("User not found");
            }

            //function to search the user
            public void search_user(string name)
            {
                foreach(Person user in Users)
                {
                    //if user exists then return
                    if(user.PersonName == name)
                    {
                        Console.WriteLine($"Person id: {user.PersonId} | Name: {user.PersonName} | Age: {user.PersonAge}");
                        return;
                    }
                }
                //if not exists, then display not found prompt
                Console.WriteLine("User not found");
            }

            //funtion to get the single book by using book id
            public Book get_book_by_id(int id)
            {
                foreach (Book book in LibraryBooks)
                {
                    //if book found return the book
                    if(book.BookId == id)
                    {
                        return book;
                    }
                }
                //if no book found return null
                return null;
            }

            //function to add the book
            public void add_book(Book book)
            {
                
                foreach(Book b in LibraryBooks)
                {
                    //if book found then display the message to change the book data
                    if(b.BookId == book.BookId)
                    {
                        Console.WriteLine("Book with this id already exists\nTry with another id");
                        return;
                    }
                }
                //if book not existed already, add it to list
                LibraryBooks.Add(book);
                Console.WriteLine($"{book.Title} added successfully");  
            }

            //function to remove the book from list
            public void remove_book(int id)
            {
                //checks if there's no book in the list
                if(LibraryBooks.Count == 0)
                {
                    Console.WriteLine("List is Alreay Empty");
                    return;
                }
                
                foreach (Book book in LibraryBooks)
                {
                    //if book found then remove
                    if(book.BookId == id)
                    {
                        LibraryBooks.Remove(book);
                        Console.WriteLine("Deleted Successfully");
                        return;
                    }
                }
                //if book not found, then prompts the not found message 
                Console.WriteLine("Book not found\nMake sure, you entered the correct id");
            }

            //function to add new book in the list
            public void view_books()
            {
                //checks if the book list empty
                if (LibraryBooks.Count == 0)
                {
                    Console.WriteLine("There's no book in the list");
                    return;
                }
                //initializing the variable to number the books
                int num = 1;
                foreach (Book book in LibraryBooks)
                {
                    Console.WriteLine($"{num} ---> {book.Title}");
                }
            }

            //function to search for book with title
            public void search_book(string title)
            {
                foreach(Book book in LibraryBooks)
                {
                    //if book found then display its info
                    if(book.Title == title)
                    {
                        book.display_info();
                        return;
                    }
                }
                //if book not found then display not found message
                Console.WriteLine("No book with this title");
            }

            //function to get the list of issued books
            public void list_issued_books()
            {
                //variable to check if any book was issued or not
                bool isAnyBookIssued = false;
                foreach(Book book in LibraryBooks)
                {
                    // if book issued then display
                    if(book.IsIssued)
                    {
                        Console.WriteLine(book.Title);
                        isAnyBookIssued = true;
                    }
                }
                //if none of the book was issued prompts the message no book found
                if (!isAnyBookIssued)
                {
                    Console.WriteLine("No Book issued");
                }
            }
        }
    }
}
