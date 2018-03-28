using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class DoctorCode
	{

        // All private and public properties of class Doctor
        private int _doctor_id;

        public int Doctor_ID
        {
            get { return _doctor_id; }
            set { _doctor_id = value; }
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

		private string _phone2;

		public string Phone2
		{
			get { return _phone2; }
			set { _phone2 = value; }
		}

		private string _adress;

		public string Adress
		{
			get { return _adress; }
			set { _adress = value; }
		}

		private string _postal_code;

		public string Postal_code
		{
			get { return _postal_code; }
			set { _postal_code = value; }
		}

		private string _city;

		public string City
		{
			get { return _city; }
			set { _city = value; }
		}

		private string _country;

		public string Country
		{
			get { return _country; }
			set { _country = value; }
		}

		private string _specialisation;

		public string Specialisation
		{
			get { return _specialisation; }
			set { _specialisation = value; }
		}

		private string _cv;

		public string CV
		{
			get { return _cv; }
			set { _cv = value; }
		}

		// All constructors

		public DoctorCode()
		{

		}

		public DoctorCode(int doctor_id_p,string name_p,string email_p,string phone1_p,string phone2_p,string adress_p,
			 string postal_code_p,string city_p,string country_p,string specialisation_p,string cv_p)
		{
            _doctor_id = doctor_id_p;
			_name = name_p;
			_email = email_p;
			_phone1 = phone1_p;
			_phone2 = phone2_p;
			_adress = adress_p;
			_postal_code = postal_code_p;
			_city = city_p;
			_country = country_p;
			_specialisation = specialisation_p;
			_cv = cv_p;
		}
	}
}

