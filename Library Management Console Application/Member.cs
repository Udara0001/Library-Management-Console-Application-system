using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application
{
    public class Member
    {
        public int Member_Id;
        public string Member_Name;
        public string Member_Address;


        public Member() { }

        public Member(int member_Id, string member_Name, string member_Address)
        {
            this.Member_Id=member_Id;
            this.Member_Name=member_Name;
            this.Member_Address=member_Address;
        }
    }
}
