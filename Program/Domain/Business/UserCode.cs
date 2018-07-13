using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
    public class UserCode
    {
        // Alle private en public properties van de class Clënt

        private int _user_id;

        public int User_ID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        
        // All constructors

        public UserCode(int ID_p,string Userame_p,string Email_p,string Password_p, string Type_p)
        {
            _user_id = ID_p;
            _username = Userame_p;
            _email = Email_p;
            _password = Password_p;
            _type = Type_p;
        }

        public UserCode()
        {

        }
    }
}
