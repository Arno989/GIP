using System;

namespace Domain.Business
{
	public class ProjectCode
	{
        public int ID { get; set; }

        public string Title { get; set; }

        public string Start_date { get; set; }

        public string End_date { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Added { get; set; }

        public DateTime Date_Last_Edited { get; set; }


        public ProjectCode()
        {

        }

        public ProjectCode(int ID_p, string Title_p, string Start_Date_p, string End_Date_p, int UserID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            ID = ID_p;
			Title = Title_p;
			Start_date = Start_Date_p;
			End_date = End_Date_p;
            UserID = UserID_p;
            Date_Added = Date_Added_p;
            Date_Last_Edited = Date_Last_Edited_p;

        }
	}
}
