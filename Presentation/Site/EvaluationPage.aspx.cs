using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class EvaluationPage: System.Web.UI.Page
	{
		BusinessCode _businesscode = new BusinessCode();

		protected void Page_Load(object sender,EventArgs e)
		{
			GridView.DataSource = _businesscode.GetEvaluations();
			GridView.DataBind();
		}
	}
}