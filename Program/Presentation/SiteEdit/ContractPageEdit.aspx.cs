using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Domain.Business;
using System.Globalization;

namespace Presentation.SiteEdit
{
	public partial class ContractPageEdit: System.Web.UI.Page
	{
        private BusinessCode _business = new BusinessCode();
        string sortingPar = "";

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
            UserCode user = (UserCode) Session["authenticatedUser"];
            if (user == null)
            {
                Response.Redirect("../index.aspx");
            }
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
            int count = 0;
            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 5; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
                    var txtBox = container.FindControl(tbName);
                    DateTime dateTime = DateTime.Today;

                    sortingPar = string.Format(" WHERE Contract_ID = {0}", GetDataIDs()[i]);
                    List<ContractCode> CurrentContract = new List<ContractCode>();
                    CurrentContract = _business.GetContracts(sortingPar);

                    switch (i2)
                    {
                        case 0:
                            ((TextBox)txtBox).Text = ListData[i][count].Replace("&nbsp;", "");
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = ListData[i][count].Replace("&nbsp;", "");
                            break;

                        case 2:
                            dateTime = DateTime.ParseExact(Convert.ToString(CurrentContract[0].End_Date), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            ((TextBox)txtBox).Text = dateTime.ToString("yyyy-MM-dd");
                            break;

                        case 3:
                            dateTime = DateTime.ParseExact(Convert.ToString(CurrentContract[0].End_Date), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            ((TextBox)txtBox).Text = dateTime.ToString("yyyy-MM-dd");
                            break;
                    }

                    string ddNameProject = "ddEdit" + i.ToString() + 0.ToString();
                    var ddProject = container.FindControl(ddNameProject) as DropDownList;

                    string ddNameClient = "ddEdit" + i.ToString() + 1.ToString();
                    var ddClient = container.FindControl(ddNameClient) as DropDownList;

                    //ProjectID krijgen van de current row in de gridvieuw
                    int ProjectID = CurrentContract[0].ProjectID;

                    //ClientID krijgen van de current row in de gridvieuw
                    int ClientID = CurrentContract[0].ClientID;

                    //de Project selecteren in de dropdown
                    ListItem liProject = ddProject.Items.FindByValue(ProjectID.ToString());
                    ddProject.ClearSelection();
                    liProject.Selected = true;

                    //de Client selecteren in de dropdown
                    ListItem liClient = ddClient.Items.FindByValue(ClientID.ToString());
                    ddClient.ClearSelection();
                    liClient.Selected = true;

                    count++;
                }
            }
        }
        
        private void SendData()
		{
            List<List<string>> ListContentProject = _business.GetProjectDropDownContent();
            List<List<string>> ListContentClient = _business.GetClientDropDownContent();
            var container = Master.FindControl("Body");

            for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[4];

                for (int i2 = 0; i2 <= 3; i2++)
				{
					string tbName = "tbEdit" + i.ToString() + i2.ToString();
					var txtBox = container.FindControl(tbName);

					switch (i2)
					{
						case 0:
							if (((TextBox) txtBox).Text != "")
							{
								input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
							else
							{
								goto track1;
							}
							break;

						case 1:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = 0.ToString();
                                ;
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = DateTime.Today.ToString();
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

						case 3:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = DateTime.Today.ToString();
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
				}

                string ddNameProject = "ddEdit" + i.ToString() + "0";
                var dropdownDataProject = container.FindControl(ddNameProject) as DropDownList;
                int indexProject = dropdownDataProject.SelectedIndex;

                string ddNameClient = "ddEdit" + i.ToString() + "1";
                var dropdownDataClient = container.FindControl(ddNameClient) as DropDownList;
                int indexClient = dropdownDataClient.SelectedIndex;

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                if (indexClient < 1 || indexProject < 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Make sure you have selected a relation.')", true);
                }
                else
                {
                    _business.AddContract(new ContractCode(0, new ContractCode(0, input[0], Convert.ToDouble(input[1]), Convert.ToDateTime(input[2]), Convert.ToDateTime(input[3]), Convert.ToInt16(ListContentClient[indexClient - 1][0]), Convert.ToInt16(ListContentProject[indexProject - 1][0]), user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow))));
                }
                track1:
				continue;
			}
		}

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        private void UpdateData()
        {
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[5];
                var container = Master.FindControl("Body");

                for (int i2 = 0; i2 <= 3; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            if (((TextBox)txtBox).Text != "")
                            {
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            else
                            {
                                goto track1;
                            }
                            break;

                        case 1:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = 0.ToString();
                                ;
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = DateTime.Today.ToString();
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 3:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = DateTime.Today.ToString();
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
                }


                string sortingPar = string.Format(" WHERE Contract_ID = {0}", GetDataIDs()[i]);
                List<ContractCode> CurrentContract = new List<ContractCode>();
                CurrentContract = _business.GetContracts(sortingPar);

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                //projectID krijgen van de current row in de gridvieuw
                int ProjectID = CurrentContract[0].ProjectID;
                string ddNameProject = "ddEdit" + i.ToString() + 0.ToString();
                var ddProject = container.FindControl(ddNameProject) as DropDownList;

                //clientID krijgen van de current row in de gridvieuw
                int ClientID = CurrentContract[0].ClientID;
                string ddNameClient = "ddEdit" + i.ToString() + 1.ToString();
                var ddClient = container.FindControl(ddNameClient) as DropDownList;
                if (ddProject.SelectedValue.Count() < 1 || ddClient.SelectedValue.Count() < 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Make sure you have selected a relation.')", true);
                }
                else
                {
                    _business.UpdateContract(ListDataIDs[i], input[0], Convert.ToDouble(input[1].TrimEnd('€')), Convert.ToDateTime(input[2]), Convert.ToDateTime(input[3]), Convert.ToInt32(ddProject.SelectedValue), Convert.ToInt32(ddClient.SelectedValue), user.ID.ToString(), dateNow);
                }
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

                if (i == 0)
                {
                    for (int i2 = 0; i2 < ListContentProject.Count; i2++)
                    {
                        names.Add(ListContentProject[i2][1]);
                    }
                }

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

                if (i == 0)
                {
                    for (int i2 = 0; i2 < ListContentclient.Count; i2++)
                    {
                        names.Add(ListContentclient[i2][1]);
                    }
                }

                DropDownData.DataSource = names;
                DropDownData.DataBind();
                for (int i2 = 0; i2 < ListContentclient.Count; i2++)
                {
                    DropDownData.Items[i2 + 1].Value = ListContentclient[i2][0];
                }
            }
        }


        protected void BtnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ContractPage.aspx");
		}

		protected void BtnSaveAndExit_Click(object sender,EventArgs e)
		{
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/ContractPage.aspx");
		}

		protected void BtnSave_Click(object sender,EventArgs e)
		{
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
                Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
            }
		}
	}
}