using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_Management_Console_Application
{
    internal class Program
    {

        static List<Book> books = new List<Book>();
        static List<Member> members = new List<Member>();
        static List<IssuBook> issuedBooks = new List<IssuBook>();
        static List<string> actionLog = new List<string>();





        static void Main(string[] args)
        {

            LoadBooksFromCSV();
            LoadMembersFromCSV();
            LoadIssuedBooKsFromCSV();




            while (true)
            {
                Console.WriteLine("\nLibrary Management System\n");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Show All Books");
                Console.WriteLine("4. show All Members");
                Console.WriteLine("5. Issue Books");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("7. View Issued Books");
                Console.WriteLine("8. Export Issued Books Report ");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBook();// write a CSV file ,all adding books
                        break;
                    case "2":
                        AddMember();
                        break;
                    case "3":
                        ShowAllBooks();// read a CSV file ,all adding books
                        break;
                    case "4":
                        ShowAllMembers();
                        break;
                    case "5":
                        IssueBook();
                        break;
                    case "6":
                        ReturnBook();
                        break;

                    case "7":
                        ViewIssuedBooks();
                        break;
                    case "8":
                        ReadIssuedBooksLog();
                        break;

                    case "9":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }

        }

        //ADD Book
        static void AddBook()
        {
            Console.Clear();

            int option = 1;



            while (option==1)
            {
                Console.Clear();
                Console.Write("Enter Book ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Book ISBN Number: ");
                int BookISBN = int.Parse(Console.ReadLine());
                Console.Write("Enter Book Name:");
                string BookName = Console.ReadLine();
                Console.Write("Enter Author Name:");
                string BookAuthor = Console.ReadLine();

                books.Add(new Book(id, BookISBN, BookName, BookAuthor));

                LogAction($"Book added: ID={id}, BookName={BookName}");

                WriteBooksToCSV(books);


                Console.WriteLine("Sucessfully Adding Book.......");

                Console.Write("\n");

                Console.WriteLine("Do you Want to add another book? :");
                Console.WriteLine("1.Yes");
                Console.WriteLine("2.No");

                option = Convert.ToInt32(Console.ReadLine());

            }




            Console.Clear();

        }


        //Write the Book name in CSV file
        static void WriteBooksToCSV(List<Book> books)
        {
            using (StreamWriter sw = new StreamWriter("Books.csv"))
            {

                sw.WriteLine("ID,ISBN,Name,Author");


                foreach (var book in books)
                {
                    sw.WriteLine($"{book.Book_Id},{book.Book_ISBN},{book.Book_Name},{book.Book_Author}");
                }
            }
        }








        //ADD Member
        static void AddMember()
        {
            Console.Clear();

            int option = 1;



            while (option==1)
            {
                Console.Clear();
                Console.Write("Enter Member ID: ");
                int MemberId = int.Parse(Console.ReadLine());

                Console.Write("Enter member Name:");
                string MemberName = Console.ReadLine();
                Console.Write("Enter  member Address:");
                string Member_Address = Console.ReadLine();

                members.Add(new Member(MemberId, MemberName, Member_Address));
                LogAction($"Member added: ID={MemberId}, Name={MemberName}");
                WriteMembersToCSV(members);




                Console.WriteLine("Sucessfully Adding member.......");

                Console.Write("\n");

                Console.WriteLine("Do you Want to add another member? :");
                Console.WriteLine("1.Yes");
                Console.WriteLine("2.No");

                option = Convert.ToInt32(Console.ReadLine());

            }




            Console.Clear();
        }


        //Write the Members name in CSV file
        static void WriteMembersToCSV(List<Member> members)
        {
            using (StreamWriter sw = new StreamWriter("Members.csv"))
            {
                sw.WriteLine("ID,Name,Address");
                foreach (var member in members)
                {
                    sw.WriteLine($"{member.Member_Id},{member.Member_Name},{member.Member_Address}");
                }
            }
        }


        static void ShowAllBooks()
        {
            Console.Clear();
            List<Book> books = ReadBooksFromCSV("Books.csv");

            Console.WriteLine("Books read from CSV file:");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Book_Id},\nISBN: {book.Book_ISBN}, \nName: {book.Book_Name}, \nAuthor: {book.Book_Author}\n\n");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }


        static void ShowAllMembers()
        {
            Console.Clear();
            List<Member> members = ReadMembersFromCSV("Members.csv");

            Console.WriteLine("Members read from CSV file:");
            foreach (var member in members)
            {
                Console.WriteLine($"Member_ID: {member.Member_Id},\nMember_Name: {member.Member_Name}, \nMember_Address: {member.Member_Address}\n\n");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        static List<Member> ReadMembersFromCSV(string filePath)
        {
            Console.Clear();

            List<Member> members = new List<Member>();

            using (StreamReader sr = new StreamReader(filePath))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    Member member = new Member
                    {
                        Member_Id= int.Parse(values[0]),
                        Member_Name = values[1],
                        Member_Address = values[2],

                    };

                    members.Add(member);
                }
            }

            return members;
        }



        static List<Book> ReadBooksFromCSV(string filePath)
        {
            Console.Clear();

            List<Book> books = new List<Book>();

            using (StreamReader sr = new StreamReader(filePath))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    Book book = new Book
                    {
                        Book_Id = int.Parse(values[0]),
                        Book_ISBN = int.Parse(values[1]),
                        Book_Name = values[2],
                        Book_Author = values[3]
                    };

                    books.Add(book);
                }
            }

            return books;
        }


        static void LoadBooksFromCSV()
        {
            if (File.Exists("Books.csv"))
            {
                books = ReadBooksFromCSV("Books.csv");
            }
        }

        static void LoadMembersFromCSV()
        {
            if (File.Exists("Members.csv"))
            {
                members = ReadMembersFromCSV("Members.csv");
            }
        }


        static void LoadIssuedBooKsFromCSV()
        {
            if (File.Exists("IssuedBooks.csv"))
            {
                issuedBooks = ReadIssuedBooksFromCSV("IssuedBooks.csv");
            }
        }




        static void IssueBook()
        {
            Console.Clear();
            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            Book book = books.FirstOrDefault(b => b.Book_Id == bookId);
            Member member = members.FirstOrDefault(m => m.Member_Id == memberId);

            if (book != null && member != null)
            {
                var issuedBook = new IssuBook(book, member, DateTime.Now);
                issuedBooks.Add(issuedBook);
                WriteIssuBooksCSV(issuedBooks);
                WriteIssuedBooksLog(issuedBook);
                LogAction($"Book issued: BookID={bookId}, MemberID={memberId}");
                Console.WriteLine("Book issued successfully.");
            }
            else
            {
                Console.WriteLine("Book or Member not found.");
            }
        }

        private static void WriteIssuedBooksLog(object issuedBook)
        {
            throw new NotImplementedException();
        }

        static void WriteIssuBooksCSV(List<IssuBook> issuedBooks)
        {
            using (StreamWriter sw = new StreamWriter("IssuedBooks.csv"))
            {
                sw.WriteLine("BookID,MemberID,IssueDate");
                foreach (var issuedBook in issuedBooks)
                {
                    sw.WriteLine($"{issuedBook.Book.Book_Id},{issuedBook.Member.Member_Id},{issuedBook.IssueDate}");
                }
            }
        }

        static List<IssuBook> ReadIssuedBooksFromCSV(string filePath)
        {
            List<IssuBook> issuedBooks = new List<IssuBook>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    IssuBook issuedBook = new IssuBook
                    {
                        Book = books.FirstOrDefault(b => b.Book_Id == int.Parse(values[0])),
                        Member = members.FirstOrDefault(m => m.Member_Id == int.Parse(values[1])),
                        IssueDate = DateTime.Parse(values[2])
                    };

                    issuedBooks.Add(issuedBook);
                }
            }

            return issuedBooks;
        }

        static void ViewIssuedBooks()
        {
            {
                Console.Clear();
                List<IssuBook> issuedBooks = ReadIssuedBooksFromCSV("IssuedBooks.csv");

                Console.WriteLine("Issued Books Report:");
                foreach (var issuedBook in issuedBooks)
                {
                    Console.WriteLine($"\n\nBook ID: {issuedBook.Book.Book_Id},\nMember ID: {issuedBook.Member.Member_Id},\nIssue Date: {issuedBook.IssueDate}\n\n");
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        static void ReturnBook()
        {
            Console.Clear();
            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            IssuBook issuedBook = issuedBooks.FirstOrDefault(ib => ib.Book.Book_Id == bookId && ib.Member.Member_Id == memberId);

            if (issuedBook != null)
            {
                issuedBooks.Remove(issuedBook);
                WriteIssuBooksCSV(issuedBooks);
                LogAction($"Book returned: BookID={bookId}");
                Console.WriteLine("Book returned successfully.");
            }
            else
            {
                Console.WriteLine("Issued book not found.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();



        }

        static void WriteIssuedBooksLog(IssuBook issuedBook)
        {
            using (StreamWriter sw = new StreamWriter("IssuedBooksLog.csv", true))
            {
                sw.WriteLine($"{issuedBook.Book.Book_Id},{issuedBook.Book.Book_Name},{issuedBook.Member.Member_Id},{issuedBook.IssueDate}");
            }
        }
        static void ReadIssuedBooksLog()
        {
            Console.Clear();

            if (File.Exists("IssuedBooksLog.csv"))
            {
                using (StreamReader sr = new StreamReader("IssuedBooksLog.csv"))
                {
                    Console.WriteLine("Issued Books Log:");
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');

                        Console.WriteLine($"\nBook Id: {values[0]}\n, Book Name: {values[1]}\n, Member Id: {values[2]}\n, Issue Date: {values[3]}\n\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("No issued books log found.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        static void LogAction(string action)
        {
            actionLog.Add($"{DateTime.Now}: {action}");



            WritelogAction(actionLog);
        }

        static void WritelogAction(List<string> actionLog)
        {
            using (StreamWriter sw = new StreamWriter("LogAction.csv"))
            {
                foreach (var log in actionLog)
                {
                    sw.WriteLine(log);
                }
            }


        }



    }
}


    

