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


        // All constructors
        
		public DepartmentCode(int department_id_p, string name_p,string email_p,string phone1_p, int hospitalID_p)
		{
            _department_id = department_id_p;
			_name = name_p;
			_email = email_p;
			_phone1 = phone1_p;
            _hospitalID = hospitalID_p;
		}
	}
}
