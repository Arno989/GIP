using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class DepartmentPageEdit: System.Web.UI.Page
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
            List<List<string>> ListData = GetData();
            int Count = 0;
            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 2; i2++)
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
                    }
                    Count++;
                }
            }
        }

        private void SendData()
        {
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[3];

                for (int i2 = 0; i2 <= 2; i2++)
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
                            if (((TextBox)txtBox).Text == "")
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                }
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (((TextBox)txtBox).Text == "")
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                }
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
                }
                _business.SetDepartment(input[0], input[1], input[2]);
                track1:
                continue;
            }
        }

        private void UpdateData()
        {
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[3];

                for (int i2 = 0; i2 <= 2; i2++)
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
                            if (((TextBox)txtBox).Text == "")
                            {
                                if (_business.IsValidEmail(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                }
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (((TextBox)txtBox).Text == "")
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                }
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
                }
                _business.UpdateDepartment(ListDataIDs[i], input[0], input[1], input[2]);
                track1:
                continue;
            }
        }


        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/DepartmentPage.aspx");
        }

        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/DepartmentPage.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
        }

	}
}