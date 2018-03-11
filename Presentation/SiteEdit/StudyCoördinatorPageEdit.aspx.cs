using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class StudyCoördinatorPageEdit: System.Web.UI.Page
	{
		private BusinessCode _business = new BusinessCode();

		private void sendData()
		{
			for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[6];

				for (int i2 = 0; i2 <= 5; i2++)
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
							if (((TextBox) txtBox).Text == "")
							{
								if (_business.IsValidEmail(((TextBox) txtBox).Text.ToString()))
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

						case 3:
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

						case 4:
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

						case 5:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
				}
				_business.SetStudyCoördinator(input[0],input[1],input[2],input[3],input[4],input[5]);
track1:
				continue;
			}
		}

		protected void Page_Load(object sender,EventArgs e)
		{

		}

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/StudyCoördinatorPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/StudyCoördinatorPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/StudyCoördinatorPageEdit.aspx");
		}
	}
}