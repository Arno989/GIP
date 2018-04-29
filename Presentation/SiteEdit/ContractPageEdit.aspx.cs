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
        
        private List<List<string>> GetData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<int> GetDataIDs()
        {
            return (List<int>)Session["DataID"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            SetDropdownContentProject();
            SetDropdownContentClient();
            if (!IsPostBack)
            {
                List<List<string>> ListData = GetData();
                if (ListData != null)
                {
                    InsertData();
                }

                Session["ListDataSession"] = null;
            }
        }
        
        private void InsertData()
        {
            List<List<string>> ListData = GetData();
            for (int i = 0; i < ListData.Count; i++)
            {


                for (int i2 = 0; i2 <= 3; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 2:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 3:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;
                    }
                }
            }
        }
        
        private void SendData()
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

        private void UpdateData()
        {
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[5];

                for (int i2 = 0; i2 <= 4; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            if (((TextBox)txtBox).Text != "")
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            else
                            {
                                goto track1;
                            }
                            break;

                        case 1:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 2:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 3:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;
                    }
                }
                _business.SetContract(input[0], Convert.ToDouble(input[1]), Convert.ToDateTime(input[2]), Convert.ToDateTime(input[3]));
                track1:
                continue;
            }
        }

        public void SetDropdownContentProject()
        {
            List<List<string>> ListContentProject = _business.GetProjectDropDownContent();
            List<string> names = new List<string>();

            for (int i = 0; i <= 9; i++)
            {
                string ddEdit = "ddEdit" + i.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDownData = container.FindControl(ddEdit) as DropDownList;
                for (int i2 = 0; i2 < ListContentProject.Count; i2++)
                {
                    if (i == 0)
                    {
                        names.Add(ListContentProject[i2][1]);
                    }
                    else
                    {
                        goto track1;
                    }
                }
                track1:
                DropDownData.DataSource = names;
                DropDownData.DataBind();
                for (int i2 = 0; i2 < ListContentProject.Count; i2++)
                {
                    DropDownData.Items[i2 + 1].Value = ListContentProject[i2][0];
                }
            }
        }

        public void SetDropdownContentClient()
        {
            List<List<string>> ListContentclient = _business.GetClientDropDownContent();
            List<string> names = new List<string>();

            for (int i = 0; i <= 9; i++)
            {
                string ddEdit = "ddEdit" + i.ToString() + "1";
                var container = Master.FindControl("Body");
                var DropDownData = container.FindControl(ddEdit) as DropDownList;
                for (int i2 = 0; i2 < ListContentclient.Count; i2++)
                {
                    if (i == 0)
                    {
                        names.Add(ListContentclient[i2][1]);
                    }
                    else
                    {
                        goto track1;
                    }
                }
                track1:
                DropDownData.DataSource = names;
                DropDownData.DataBind();
                for (int i2 = 0; i2 < ListContentclient.Count; i2++)
                {
                    DropDownData.Items[i2 + 1].Value = ListContentclient[i2][0];
                }
            }
        }

        protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ContractPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			SendData();
			Response.Redirect("../Site/ContractPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			SendData();
			Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
		}
	}
}