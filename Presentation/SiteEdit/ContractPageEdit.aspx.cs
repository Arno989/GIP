using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class ContractPageEdit: System.Web.UI.Page
	{
		private BusinessCode _business = new BusinessCode();

		private void sendData()
		{
			for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[4];

				for (int i2 = 0; i2 <= 3; i2++)
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

						case 3:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
				}
				_business.SetContract(input[0],Convert.ToDouble(input[1]),Convert.ToDateTime(input[2]),Convert.ToDateTime(input[3]));
track1:
				continue;
			}
		}
		
		protected void Page_Load(object sender,EventArgs e)
		{

		}

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ContractPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/ContractPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
		}
	}
}