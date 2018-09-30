using System;

namespace Domain.Business
{
	public class ContractCode
	{
        public int ID { get; set; }

        public string Legal_Country { get; set; }

        public string Fee { get; set; }

        public string Start_Date { get; set; }

        public string End_Date { get; set; }

        public int ProjectID { get; set; }

        public int ClientID { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Added { get; set; }

        public DateTime Date_Last_Edited { get; set; }


        public ContractCode()
        {

        }

        public ContractCode(int ID_p, string Legal_Country_p, string Fee_p, string Start_Date_p, string End_Date_p, int ProjectID_p, int ClientID_p, int UserID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            ID = ID_p;
            Legal_Country = Legal_Country_p;
			Fee = Fee_p;
            Start_Date = Start_Date_p;
            End_Date = End_Date_p;
            ProjectID = ProjectID_p;
            ClientID = ClientID_p;
            UserID = UserID_p;
            Date_Added = Date_Added_p;
            Date_Last_Edited = Date_Last_Edited_p;
        }
	}
}
