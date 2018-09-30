using System;

namespace Domain.Business
{
	public class DepartmentCode
	{
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int HospitalID { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Added { get; set; }

        public DateTime Date_Last_Edited { get; set; }


        public DepartmentCode()
        {

        }

        public DepartmentCode(int ID_p, string Name_p, string Email_p, string Phone_p, int HospitalID_p, int UserID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            ID = ID_p;
			Name = Name_p;
			Email = Email_p;
			Phone = Phone_p;
            HospitalID = HospitalID_p;
            UserID = UserID_p;
            Date_Added = Date_Added_p;
            Date_Last_Edited = Date_Last_Edited_p;
        }
	}
}
