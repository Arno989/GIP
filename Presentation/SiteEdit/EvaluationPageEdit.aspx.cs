using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class EvaluationPageEdit: System.Web.UI.Page
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
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 3:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 4:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 5:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
				}
				_business.SetEvaluation(Convert.ToDateTime(input[0]),input[1],input[2],input[3],input[4],input[5]);
track1:
				continue;
			}
		}

        public void SetDropdownContent()
        {
            List<List<string>> ListContentCRA = _business.GetCRADropDownContent();
            List<List<string>> ListContentDoctor = _business.GetDoctorDropDownContent();
            List<List<string>> ListContentStudyCoordinator = _business.GetStudyCoordinatorDropDownContent();
            List<string> names = new List<string>();
            int count = 1;

            if (ListContentCRA.Count > 0)
            {
                names.Add("----CRA's");
                for (int i2 = 0; i2 < ListContentCRA.Count; i2++)
                {
                    if (count % 2 != 0)
                    {
                        names.Add(ListContentCRA[i2][count]);
                    }
                    count = count + 2;
                }
                count = 1;
            }

            if (ListContentDoctor.Count > 0)
            {
                names.Add("----Doctors");
                for (int i2 = 0; i2 < ListContentDoctor.Count; i2++)
                {
                    if (count % 2 != 0)
                    {
                        names.Add(ListContentDoctor[i2][count]);
                    }
                    count = count + 2;
                }
                count = 1;
            }

            if (ListContentStudyCoordinator.Count > 0)
            {
                names.Add("----Study Coördinators");
                for (int i2 = 0; i2 < ListContentStudyCoordinator.Count; i2++)
                {
                    if (count % 2 != 0)
                    {
                        names.Add(ListContentStudyCoordinator[i2][count]);
                    }
                    count = count + 2;
                }
                count = 1;
            }

            for (int i = 0; i <= 9; i++)
            {
                string ddEdit = "ddEdit" + i.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDown = container.FindControl(ddEdit) as DropDownList;
                DropDown.DataSource = names;
                DropDown.DataBind();
            }
        }

        protected void Page_Load(object sender,EventArgs e)
		{
            SetDropdownContent();
		}

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/EvaluationPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/EvaluationPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
		}
	}
}