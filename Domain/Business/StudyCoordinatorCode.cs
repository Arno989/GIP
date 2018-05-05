using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class StudyCoordinatorCode
	{

        // All private and public properties of class StudyCoördinator
        private int _studycoordinator_id;

        public int StudyCoordinator_ID
        {
            get { return _studycoordinator_id; }
            set { _studycoordinator_id = value; }
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

		private string _specialisation;

		public string Specialisation
		{
			get { return _specialisation; }
			set { _specialisation = value; }
		}

		// All constructors
        
		public StudyCoordinatorCode(int studycoordinator_id_p, string name_p,string cv_p,string email_p,string phone1_p,string phone2_p,string specialisation_p)
		{
            _studycoordinator_id = studycoordinator_id_p;
			_name = name_p;
			_cv = cv_p;
			_email = email_p;
			_phone1 = phone1_p;
			_phone2 = phone2_p;
			_specialisation = specialisation_p;
		}

	}
}
