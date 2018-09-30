using System;

namespace Domain.Business
{
	public class EvaluationCode
	{
        public int ID { get; set; }

        public string Date { get; set; }

        public string Feedback { get; set; }

        public string Accuracy { get; set; }

        public string Quality { get; set; }

        public string Evaluation_txt { get; set; }

        public string Label { get; set; }

        public int CraID { get; set; }

        public int DoctorID { get; set; }

        public int StudyCoordinatorID { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Added { get; set; }

        public DateTime Date_Last_Edited { get; set; }


        public EvaluationCode()
        {
            
        }

        public EvaluationCode(int ID_p, string Date_p, string Feedback_p, string Accuracy_p,
			 string Quality_p, string Evaluation_txt_p, string Label_p, int CraID_p, int DoctorID_p, int StudyCoordinatorID_p, int UserID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            ID = ID_p;
			Date = Date_p;
			Feedback = Feedback_p;
			Accuracy = Accuracy_p;
			Quality = Quality_p;
			Evaluation_txt = Evaluation_txt_p;
			Label = Label_p;
            CraID = CraID_p;
            DoctorID = DoctorID_p;
            StudyCoordinatorID = StudyCoordinatorID_p;
            UserID = UserID_p;
            Date_Added = Date_Added_p;
            Date_Last_Edited = Date_Last_Edited_p;
        }
	}
}
