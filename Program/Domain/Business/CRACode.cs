using System;

namespace Domain.Business
{
	public class CRACode
	{
        public int ID { get; set; }

        public string Name { get; set; }

        public string CV { get; set; }

        public string Email { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Added { get; set; }

        public DateTime Date_Last_Edited { get; set; }


        public CRACode()
        {

        }

        public CRACode(int ID_p,string Name_p,string CV_p,string Email_p,string Phone1_p,string Phone2_p, int UserID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            ID = ID_p;
			Name = Name_p;
			CV = CV_p;
			Email = Email_p;
			Phone1 = Phone1_p;
			Phone2 = Phone2_p;
            UserID = UserID_p;
            Date_Added = Date_Added_p;
            Date_Last_Edited = Date_Last_Edited_p;
        }
	}
}
