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

		// All constructors

		public ProjectCode()
		{

		}

		public ProjectCode(string title_p,string start_date_p,string end_date_p)
		{
			_title = title_p;
			_start_date = start_date_p;
			_end_date = end_date_p;
		}

	}
}
