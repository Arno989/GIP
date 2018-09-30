using System;

namespace Domain.Business
{
    public class UserCode
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }


        public UserCode()
        {

        }

        public UserCode(int ID_p,string Userame_p,string Email_p,string Password_p, string Type_p)
        {
            ID = ID_p;
            Username = Userame_p;
            Email = Email_p;
            Password = Password_p;
            Type = Type_p;
        }
    }
}
