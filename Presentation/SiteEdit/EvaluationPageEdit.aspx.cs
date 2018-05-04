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

        private List<List<string>> GetData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<int> GetDataIDs()
        {
            return (List<int>)Session["DataID"];
        }

        private void SendData()
		{
			for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[6];
                var container = Master.FindControl("Body");

                for (int i2 = 0; i2 <= 5; i2++)
				{
					string tbName = "tbEdit" + i.ToString() + i2.ToString();
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

                List<List<string>> ListContentCRA = _business.GetCRADropDownContent();
                List<List<string>> ListContentDoctor = _business.GetDoctorDropDownContent();
                List<List<string>> ListContentSC = _business.GetStudyCoordinatorDropDownContent();
                List<string> Empty = new List<string>();
                Empty.Add(string.Empty);
                List<List<string>> ListAll = new List<List<string>>();

                ListAll.Add(Empty);
                ListAll.Add(Empty);
                for(int i3 = 0; i3 < ListContentCRA.Count; i3++)
                {
                    ListAll.Add(ListContentCRA[i3]);
                }
                ListAll.Add(Empty);
                for (int i3 = 0; i3 < ListContentDoctor.Count; i3++)
                {
                    ListAll.Add(ListContentDoctor[i3]);
                }
                ListAll.Add(Empty);
                for (int i3 = 0; i3 < ListContentSC.Count; i3++)
                {
                    ListAll.Add(ListContentSC[i3]);
                }

                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                int index = dropdownData.SelectedIndex;

                if(index > 1 && index <= 1 + ListContentCRA.Count)
                {
                    _business.SetEvaluation(Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], Convert.ToInt16(ListAll[index][0]), 0, 0);
                }
                else if (index > 2 + ListContentCRA.Count && index <= 1 + ListContentCRA.Count + 1 + ListContentDoctor.Count)
                {
                    _business.SetEvaluation(Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], 0, Convert.ToInt16(ListAll[index][0]), 0);
                }
                else if (index > 2 + ListContentCRA.Count + 1 + ListContentDoctor.Count)
                {
                    _business.SetEvaluation(Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], 0, 0, Convert.ToInt16(ListAll[index][0]));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Make sure you have selected a valid relation.')", true);
                }
                track1:
				continue;
			}
		}

        public void UpdateData()
        {

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
                        names.Add(ListContentCRA[i2][1]);
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
                        names.Add(ListContentDoctor[i2][1]);
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
                        names.Add(ListContentStudyCoordinator[i2][1]);
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

                int StartCRA = 2;
                int StartDoctor = StartCRA + ListContentCRA.Count + 1;
                int StartSC = StartDoctor + ListContentDoctor.Count + 1;
                int total = StartSC + ListContentStudyCoordinator.Count;

                int count1 = 0;

                for (int i2 = 2; i2  < ListContentCRA.Count + 2; i2++)
                {
                    DropDown.Items[i2].Value = ListContentCRA[count1][0];
                    count1++;
                }
                count1 = 0;
                for(int i2 = StartDoctor; i2 < StartDoctor + ListContentDoctor.Count; i2++)
                {
                    DropDown.Items[i2].Value = ListContentDoctor[count1][0];
                    count1++;
                }
                count1 = 0;
                for(int i2 = StartSC; i2 < StartSC + ListContentStudyCoordinator.Count; i2++)
                {
                    DropDown.Items[i2].Value = ListContentStudyCoordinator[count1][0];
                    count1++;
                }
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
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/EvaluationPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
		}
	}
}