using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class HospitalCode
	{

        // All private and public properties of class Hospital
        private int _hospital_id;

        public int Hospital_ID
        {
            get { return _hospital_id; }
            set { _hospital_id = value; }
        }

        private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
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

		private string _central_number;

		public string Central_number
		{
			get { return _central_number; }
			set { _central_number = value; }
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

        public HospitalCode(int hospital_id_p,string name_p,string adress_p,string postal_code_p,string city_p,
			 string country_p,string central_number_p, int User_ID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            _hospital_id = hospital_id_p;
			_name = name_p;
			_adress = adress_p;
			_postal_code = postal_code_p;
			_city = city_p;
			_country = country_p;
			_central_number = central_number_p;
            _user_id = User_ID_p;
            _date_added = Date_Added_p;
            _date_last_edited = Date_Last_Edited_p;
        }
	}
}
