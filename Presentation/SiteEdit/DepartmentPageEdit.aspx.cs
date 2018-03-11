using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class DepartmentPageEdit: System.Web.UI.Page
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
							if (((TextBox) txtBox).Text == "")
							{
								if (_business.IsValidPhone(((TextBox) txtBox).Text.ToString()))
								{
									input[i2] = (((TextBox) txtBox).Text.ToString());
								}
								else
								{
									//error---------------------------------------
								}
							}
							else
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}
							break;

						case 2:
							if (((TextBox) txtBox).Text == "")
							{
								if (_business.IsValidPhone(((TextBox) txtBox).Text.ToString()))
								{
									input[i2] = (((TextBox) txtBox).Text.ToString());
								}
								else
								{
									//error---------------------------------------
								}
							}
							else
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}
							break;
					}
				}
				_business.SetDepartment(input[0],input[1],input[2]);
track1:
				continue;
			}
		}

		protected void Page_Load(object sender,EventArgs e)
		{

		}

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/DepartmentPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/DepartmentPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
		}
	}
}