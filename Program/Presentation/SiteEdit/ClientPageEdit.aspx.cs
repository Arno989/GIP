using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class ClientSiteEdit: System.Web.UI.Page
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
            UserCode user = (UserCode) Session["authenticatedUser"];
            if (user == null)
            {
                Response.Redirect("~/index.aspx");
            }
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

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        private void InsertData()
        {
            List < List<string> > ListData = GetData();
            int Count = 0;
            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 7; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 2:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 3:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 4:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 5:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 6:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 7:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;
                    }
                    Count++;
                }
            }
        }

		private void SendData()
		{
            for (int i = 0; i <= 9; i++)
			{
				string[] input = new string[8];

				for (int i2 = 0; i2 <= 7; i2++)
				{
					string tbName = "tbEdit" + i.ToString() + i2.ToString();
					var container = Master.FindControl("Body");
					var txtBox = container.FindControl(tbName);

					switch (i2)
					{
						case 0:
							if (((TextBox) txtBox).Text != "")
							{
								input[i2] = _business.BeginUpperCase((((TextBox) txtBox).Text.ToString()));
							}
                            else
                            {
                                goto track1;
                            }
							break;

						case 1:
							input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 2:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 3:
							input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 4:
							input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 5:
							input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 6:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 7:
							input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;
					}
				}

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.User_ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.SetClient(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7], user.User_ID.ToString(), dateNow, dateNow);
                track1:
                continue;
			}
		}

        private void UpdateData()
        {
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[8];

                for (int i2 = 0; i2 <= 7; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
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
                            input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 2:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 3:
                            input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 4:
                            input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 5:
                            input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 6:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 7:
                            input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;
                    }
                }

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.User_ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.UpdateClient(ListDataIDs[i], input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], user.User_ID.ToString(), dateNow);
                track1:
                continue;
            }
        }


        protected void BtnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ClientPage.aspx");
		}

		protected void BtnSaveAndExit_Click(object sender,EventArgs e)
		{
            if(GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
			Response.Redirect("../Site/ClientPage.aspx");
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
                Response.Redirect("../SiteEdit/ClientPageEdit.aspx");
            }
		}
	}
}