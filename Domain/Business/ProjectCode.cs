using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
	public class ProjectCode
	{

        // All private and public properties of class Project
        private int _project_id;

        public int Project_ID
        {
            get { return _project_id; }
            set { _project_id = value; }
        }

        private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		private string _start_date;

		public string Start_date
		{
			get { return _start_date; }
			set { _start_date = value; }
		}

		private string _end_date;

		public string End_date
		{
			get { return _end_date; }
			set { _end_date = value; }
		}

        private int _user_id;

        public int User_ID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private DateTime _date_added;

        public DateTime Date_Added
        {
            get { return _date_added; }
            set { _date_added = value; }
        }

        private DateTime _date_last_edited;

        public DateTime Date_Last_Edited
        {
            get { return _date_last_edited; }
            set { _date_last_edited = value; }
        }

        // All constructors

        public ProjectCode(int project_id_p,string title_p,string start_date_p,string end_date_p, int User_ID_p, DateTime Date_Added_p, DateTime Date_Last_Edited_p)
		{
            _project_id = project_id_p;
			_title = title_p;
			_start_date = start_date_p;
			_end_date = end_date_p;
            _user_id = User_ID_p;
            _date_added = Date_Added_p;
            _date_last_edited = Date_Last_Edited_p;

        }

	}
}
