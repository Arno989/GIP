using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class DepartmentCode
	{

        // All private and public properties of class Department
        private int _department_id;

        public int Department_ID
        {
            get { return _department_id; }
            set { _department_id = value; }
        }

        private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private string _phone1;

		public string Phone1
		{
			get { return _phone1; }
			set { _phone1 = value; }
		}

        private int _hospitalID;

        public int HospitalID
        {
            get { return _hospitalID; }
            set { _hospitalID = value; }
        }

        private int _user_id;

        public int User_ID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private DateTime _date_added;

        public DateTime Date_Added
        {
            get { return _date_added; }
            set { _date_added = value; }
        }

        private DateTime _date_last_edited;

        public DateTime Date_Last_Edited
        {
            get { return _date_last_edited; }
            set { _date_last_edited = value; }
        }

        // All constructors

        public DepartmentCode(int department_id_p, string name_p,string email_p,string phone1_p, int hospitalID_p, int User_ID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            _department_id = department_id_p;
			_name = name_p;
			_email = email_p;
			_phone1 = phone1_p;
            _hospitalID = hospitalID_p;
            _user_id = User_ID_p;
            _date_added = Date_Added_p;
            _date_last_edited = Date_Last_Edited_p;
        }
	}
}
