using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application
{
     public class Book
    {
        public int Book_Id;
        public int Book_ISBN;
        public string Book_Name;
        public string Book_Author;


        public Book() { }

        public Book(int Book_Id, int Book_ISBN, string Book_Name, string Book_Author)
        {
            this.Book_Id = Book_Id;
            this.Book_Author = Book_Author;
            this.Book_ISBN = Book_ISBN;
            this.Book_Name = Book_Name;

        }
    }
}
