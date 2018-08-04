using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class ClientSiteEdit: System.Web.UI.Page
	{
		private BusinessCode _businesscode = new BusinessCode();

        private List<List<string>> GetSessionData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<int> GetSessionDataIDs()
        {
            return (List<int>)Session["DataID"];
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _businesscode.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            UserCode user = (UserCode) Session["authenticatedUser"];
            if (user == null)
                Response.Redirect("~/index.aspx");
            if (!IsPostBack)
            {
                List<List<string>> ListData = GetSessionData();
                if (ListData != null)
                {
                    LoadData();
                }

                Session["ListDataSession"] = null;
            }
        }
        

        private void LoadData()
        {
            List<int> ListDataIDs = GetSessionDataIDs();
            List<ClientCode> clients = new List<ClientCode>();
            foreach (int ID in ListDataIDs)
                clients.Add(_businesscode.GetClients($"WHERE Client_ID = {ID}")[0]);

            for (int i = 0; i < ListDataIDs.Count; i++)
            {
                for (int i2 = 0; i2 <= 7; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            ((TextBox)txtBox).Text = clients[i].Name;
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = clients[i].Adress;
                            break;

                        case 2:
                            ((TextBox)txtBox).Text = clients[i].Postal_Code;
                            break;

                        case 3:
                            ((TextBox)txtBox).Text = clients[i].City;
                            break;

                        case 4:
                            ((TextBox)txtBox).Text = clients[i].Country;
                            break;

                        case 5:
                            ((TextBox)txtBox).Text = clients[i].Contact_Person;
                            break;

                        case 6:
                            ((TextBox)txtBox).Text = clients[i].Invoice_Info;
                            break;

                        case 7:
                            ((TextBox)txtBox).Text = clients[i].Kind_of_Client;
                            break;
                    }
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
								input[i2] = _businesscode.BeginUpperCase((((TextBox) txtBox).Text.ToString()));
                            else
                                goto track1;
							break;

						case 1:
							input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 2:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 3:
							input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 4:
							input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 5:
							input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;

						case 6:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 7:
							input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
							break;
					}
				}

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.User_ID);
                
                ClientCode client = new ClientCode(0, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], user.User_ID, DateTime.Now, DateTime.Now);
                _businesscode.AddClient(client);
                track1:
                continue;
			}
		}

        private void UpdateData()
        {
            List<int> ListDataIDs = GetSessionDataIDs();
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
                                input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            else
                                goto track1;
                            break;

                        case 1:
                            input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 2:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 3:
                            input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 4:
                            input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 5:
                            input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;

                        case 6:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 7:
                            input[i2] = _businesscode.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            break;
                    }
                }

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.User_ID);

                ClientCode client = new ClientCode(0, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], user.User_ID, DateTime.Now, DateTime.Now);
                _businesscode.UpdateClient(client);
                track1:
                continue;
            }
        }


        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/ClientPage.aspx");
        }

		protected void BtnSaveAndExit_Click(object sender,EventArgs e)
		{
            if(GetSessionDataIDs() != null)
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
            if (GetSessionDataIDs() != null)
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