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
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 2:
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 3:
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 4:
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 5:
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 6:
                            ((TextBox)txtBox).Text = ListData[i][Count];
                            break;

                        case 7:
                            ((TextBox)txtBox).Text = ListData[i][Count];
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

						case 6:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 7:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
				}
				_business.SetClient(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7]);
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

                        case 4:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 5:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 6:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;

                        case 7:
                            input[i2] = (((TextBox)txtBox).Text.ToString());
                            break;
                    }
                }
                _business.UpdateClient(ListDataIDs[i], input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7]);
                track1:
                continue;
            }
        }


        protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ClientPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
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
            Response.Redirect("../SiteEdit/ClientPageEdit.aspx");
		}
	}
}