using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class EvaluationCode
	{

        // All private and public properties of class Evaluation
        private int _evaluation_id;

        public int Evaluation_ID
        {
            get { return _evaluation_id; }
            set { _evaluation_id = value; }
        }


        private string _date;

		public string Date
		{
			get { return _date; }
			set { _date = value; }
		}

		private string _feedback;

		public string Feedback
		{
			get { return _feedback; }
			set { _feedback = value; }
		}

		private string _accuracy;

		public string Accuracy
		{
			get { return _accuracy; }
			set { _accuracy = value; }
		}

		private string _quality;

		public string Quality
		{
			get { return _quality; }
			set { _quality = value; }
		}

		private string _evaluation_txt;

		public string Evaluation_txt
		{
			get { return _evaluation_txt; }
			set { _evaluation_txt = value; }
		}

		private string _label;

		public string Label
		{
			get { return _label; }
			set { _label = value; }
		}

        private int _craID;

        public int CraID
        {
            get { return _craID; }
            set { _craID = value; }
        }

        private int _doctortID;

        public int DoctorID
        {
            get { return _doctortID; }
            set { _doctortID = value; }
        }

        private int _scID;

        public int ScID
        {
            get { return _scID; }
            set { _scID = value; }
        }

        // All constructors
        
		public EvaluationCode(int evaluation_id_p,string date_p,string feedback_p,string accuracy_p,
			 string quality_p,string evaluation_txt_p,string label_p, int cra_id_p, int doctor_id_p, int sc_id_p)
		{
            _evaluation_id = evaluation_id_p;
			_date = date_p;
			_feedback = feedback_p;
			_accuracy = accuracy_p;
			_quality = quality_p;
			_evaluation_txt = evaluation_txt_p;
			_label = label_p;
            _craID = cra_id_p;
            _doctortID = doctor_id_p;
            _scID = sc_id_p;
		}
	}
}
