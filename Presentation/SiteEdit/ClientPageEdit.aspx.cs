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

        private void InsertData()
        {
            List < List<string> > ListData = GetData();
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
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 2:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 3:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 4:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 5:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 6:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;

                        case 7:
                            ((TextBox)txtBox).Text = ListData[i][i2];
                            break;
                    }
                }
            }
        }

		private void sendData()
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

		protected void Page_Load(object sender,EventArgs e)
		{
            List<List<string>> ListData = GetData();
            if (ListData != null)
            {
                InsertData();
            }
		}

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/ClientPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/ClientPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/ClientPageEdit.aspx");
		}
	}
}