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
        private int _contract_id;

        public int Contract_ID
        {
            get { return _contract_id; }
            set { _contract_id = value; }
        }

        private string _legal_country;

		public string Legal_country
		{
			get { return _legal_country; }
			set { _legal_country = value; }
		}

		private string _fee;

		public string Fee
		{
			get { return _fee; }
			set { _fee = value; }
		}

		private string _start_date;

		public string Start_Date
		{
			get { return _start_date; }
			set { _start_date = value; }
		}

		private string _end_date;

		public string End_Date
		{
			get { return _end_date; }
			set { _end_date = value; }
		}

        private int _projectID;

        public int ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }

        private int _clienID;

        public int ClientID
        {
            get { return _clienID; }
            set { _clienID = value; }
        }

        // All constructors

        public ContractCode()
		{

		}

		public ContractCode(int _contract_id_p, string legal_country_p,string fee_p,string startdate_p,string enddate_p, int projectID_p, int clientID_p)
		{
            _contract_id = _contract_id_p;
            _legal_country = legal_country_p;
			_fee = fee_p;
            _start_date = startdate_p;
            _end_date = enddate_p;
            _projectID = projectID_p;
            _clienID = clientID_p;
        }
	}
}
