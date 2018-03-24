using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using MySql.Data.MySqlClient;

namespace Presentation.SiteEdit
{
	public partial class DoctorPageEdit: System.Web.UI.Page
	{
		private BusinessCode _business = new BusinessCode();
		
		private void sendData()
		{
			for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[10];

				for (int i2 = 0; i2 <= 9; i2++)
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
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 5:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 6:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 7:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 8:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 9:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
				}
				_business.SetDoctor(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7],input[8],input[9]);
track1:
				continue;
			}
		}

        public void SetDropdownContent()
        {
            for (int i = 0; i <= 9; i++)
            {

                for (int i2 = 0; i2 <= 7; i2++)
                {
                    string ddEdit = "ddEdit" + i.ToString() + "0";
                    var container = Master.FindControl("Body");
                    var container2 = container.FindControl("Table");
                    var DropDown = container2.FindControl(ddEdit) as DropDownList;
                    DropDown.DataSource = _business.GetHospitalDropDownContent();
                    DropDown.DataBind();
                }
            }
        }

		protected void Page_Load(object sender,EventArgs e)
		{
            SetDropdownContent();
        }

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/DoctorPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/DoctorPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
		}
	}
}