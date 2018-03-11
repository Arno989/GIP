using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class ProjectPageEdit: System.Web.UI.Page
	{
		private BusinessCode _business = new BusinessCode();

		private void sendData()
		{
			for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[3];

				for (int i2 = 0; i2 <= 2; i2++)
				{
					string tbName = "tbEdit" + i.ToString() + i2.ToString();
					var container = Master.FindControl("Body");
					var txtBox = container.FindControl(tbName);

					switch (i2)
					{
						case 0:
							if (((TextBox) txtBox).Text != "")
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}
							else
							{
								goto track1;
							}
							break;

						case 1:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 2:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
				}
				_business.SetProject(input[0],Convert.ToDateTime(input[1]),Convert.ToDateTime(input[2]));
track1:
				continue;
			}
		}

		protected void Page_Load(object sender,EventArgs e)
		{

		}

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ProjectPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/ProjectPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/ProjectPageEdit.aspx");
		}
	}
}