using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class ContractCode
	{

		// Alle private en public properties van de class Contract
		private string _legal_country;

		public string Legal_country
		{
			get { return _legal_country; }
			set { _legal_country = value; }
		}

		private double _fee;

		public double Fee
		{
			get { return _fee; }
			set { _fee = value; }
		}

		private string _duration;

		public string Duration
		{
			get { return _duration; }
			set { _duration = value; }
		}

		private string _date;

		public string Date
		{
			get { return _date; }
			set { _date = value; }
		}

		// All constructors

		public ContractCode()
		{

		}

		public ContractCode(string legal_country_p,double fee_p,string duration_p,string date_p)
		{
			_legal_country = legal_country_p;
			_fee = fee_p;
			_duration = duration_p;
			_date = date_p;
		}
	}
}
