using System;

namespace Domain.Business
{
	public class HospitalCode
	{
        public int ID { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Postal_Code { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Central_number { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Added { get; set; }

        public DateTime Date_Last_Edited { get; set; }


        public HospitalCode()
        {

        }

        public HospitalCode(int ID_p, string Name_p, string Adress_p, string Postal_Code_p, string City_p,
			 string Country_p, string Central_Number_p, int UserID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            ID = ID_p;
			Name = Name_p;
			Adress = Adress_p;
			Postal_Code = Postal_Code_p;
			City = City_p;
			Country = Country_p;
			Central_number = Central_Number_p;
            UserID = UserID_p;
            Date_Added = Date_Added_p;
            Date_Last_Edited = Date_Last_Edited_p;
        }
	}
}
