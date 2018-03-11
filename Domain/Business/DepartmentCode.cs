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

		// All constructors

		public DepartmentCode()
		{

		}

		public DepartmentCode(string name_p,string email_p,string phone1_p)
		{
			_name = name_p;
			_email = email_p;
			_phone1 = phone1_p;
		}
	}
}
