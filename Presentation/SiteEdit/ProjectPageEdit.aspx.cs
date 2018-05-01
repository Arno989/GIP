using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class ProjectPageEdit: System.Web.UI.Page
	{
        private BusinessCode _business = new BusinessCode();
        string sortingPar = "";

        private List<List<string>> GetSessionData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<int> GetSessionDataIDs()
        {
            return (List<int>)Session["DataID"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<List<string>> ListData = GetSessionData();
                if (ListData != null)
                {
                    InsertData();
                }

                Session["ListDataSession"] = null;
            }
        }

        private void InsertData()
        {
            List<List<string>> ListDataSession = GetSessionData();
            var container = Master.FindControl("Body");

            for (int i = 0; i < ListDataSession.Count; i++)
            {
                for (int i2 = 0; i2 <= 2; i2++) //--Var
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    ((TextBox)txtBox).Text = ListDataSession[i][i2].Replace("&nbsp;", "");
                }
            }
        }

        private void SendData()
        {
            for (int i = 0; i < 10; i++)
            {
                var container = Master.FindControl("Body");
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 2; i2++) //--Var
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                goto track1;
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 1:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
                }
                _business.SetProject(input[0], Convert.ToDateTime(input[1]), Convert.ToDateTime(input[2])); //--Var

                track1:
                continue;
            }
        }

        private void UpdateData()
        {
            List<int> ListDataIDs = GetSessionDataIDs();

            for (int i = 0; i < ListDataIDs.Count; i++)
            {
                var container = Master.FindControl("Body");
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 2; i2++) //--Var
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                goto track1;
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 1:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
                }
                _business.UpdateProject(ListDataIDs[i], input[0], Convert.ToDateTime(input[1]), Convert.ToDateTime(input[2])); //--Var

                track1:
                continue;
            }
        }


        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/ProjectPage.aspx"); //--Var
        }

        protected void BtnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (GetSessionDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/ProjectPage.aspx");  //--Var
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GetSessionDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../SiteEdit/ProjectPageEdit.aspx");  //--Var
        }
    }
}