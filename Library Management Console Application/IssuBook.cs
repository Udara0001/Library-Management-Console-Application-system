using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application
{
     public  class IssuBook
    {

        public Book Book;
        public Member Member;
        public DateTime IssueDate;


        public IssuBook() { }

        public IssuBook(Book book, Member member, DateTime issueDate)
        {
            this.Book = book;
            this.Member = member;
            this.IssueDate = issueDate;
        }
    

}
}
