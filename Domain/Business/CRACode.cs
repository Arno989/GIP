using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class CRACode
	{

        // All private and public properties of class Doctor
        private int _cra_id;

        public int CRA_ID
        {
            get { return _cra_id; }
            set { _cra_id = value; }
        }

        private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _cv;

		public string CV
		{
			get { return _cv; }
			set { _cv = value; }
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

		private string _phone2;

		public string Phone2
		{
			get { return _phone2; }
			set { _phone2 = value; }
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

        public CRACode(int cra_id_p,string name_p,string cv_p,string email_p,string phone1_p,string phone2_p, int User_ID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            _cra_id = cra_id_p;
			_name = name_p;
			_cv = cv_p;
			_email = email_p;
			_phone1 = phone1_p;
			_phone2 = phone2_p;
            _user_id = User_ID_p;
            _date_added = Date_Added_p;
            _date_last_edited = Date_Last_Edited_p;
        }
	}
}
