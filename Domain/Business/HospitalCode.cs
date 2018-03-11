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

		// All constructors

		public HospitalCode()
		{

		}

		public HospitalCode(string name_p,string adress_p,string postal_code_p,string city_p,
			 string country_p,string central_number_p)
		{
			_name = name_p;
			_adress = adress_p;
			_postal_code = postal_code_p;
			_city = city_p;
			_country = country_p;
			_central_number = central_number_p;
		}
	}
}
