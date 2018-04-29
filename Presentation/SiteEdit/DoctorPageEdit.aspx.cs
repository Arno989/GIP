using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class DoctorPageEdit: System.Web.UI.Page
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
            SetListBoxContent();

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

        public void SetListBoxContent()
        {
            if (!IsPostBack)
            {
                List<List<string>> ListDropdownContent = _business.GetHospitalDropDownContent(); //--Var
                List<string> Names = new List<string>();

                string ddEdit = "lbEdit" + 0.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDownData = container.FindControl(ddEdit) as ListBox;

                for (int i2 = 0; i2 < ListDropdownContent.Count; i2++)
                {
                    Names.Add(ListDropdownContent[i2][1]);
                }
                DropDownData.DataSource = Names;
                DropDownData.DataBind();

                for (int i2 = 0; i2 < ListDropdownContent.Count; i2++)
                {
                    DropDownData.Items[i2 + 1].Value = ListDropdownContent[i2][0];
                }
            }
        }


        private void InsertData()
        {
            List<List<string>> ListData = GetSessionData();
            var container = Master.FindControl("Body");

            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 9; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
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

                        case 4:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 5:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 6:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 7:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 8:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;

                        case 9:
                            ((TextBox)txtBox).Text = ListData[i][i2].Replace("&nbsp;", "");
                            break;
                    }
                }
                
                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;

                List<int> IdSubject = GetSessionDataIDs();
                List<int> IdRel = _business.GetRelationHospitalHasDoctor(IdSubject[i]); //--Var

                if (IdRel.Count > 0)
                {
                    foreach (int IdRel1 in IdRel)
                    {
                        ListItem li = listboxData.Items.FindByValue(IdRel1.ToString());
                        li.Selected = true;
                    }
                    IdRel.Clear();
                }
            }
        }

        private void SendData()
        {
            var container = Master.FindControl("Body");

            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 9; i2++)
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
                                if (_business.IsValidEmail(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid email";
                                }
                            }

                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid phone";
                                }
                            }
                            break;

                        case 3:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid phone";
                                }
                            }
                            break;

                        case 4:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 5:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 6:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 7:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 8:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 9:
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
                _business.SetDoctor(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]); //--Var

                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;
                
                if (listboxData.SelectedIndex != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            DoctorCode doctor = _business.GetDoctors(sortingPar).Last(); //--Var
                            _business.AddHospitalToDoctor(Convert.ToInt16(l.Value.ToString()), doctor.Doctor_ID); //--Var
                        }
                    }
                }
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

                for (int i2 = 0; i2 <= 9; i2++)
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
                                if (_business.IsValidEmail(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid email";
                                }
                            }

                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid phone";
                                }
                            }
                            break;

                        case 3:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid phone";
                                }
                            }
                            break;

                        case 4:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 5:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 6:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 7:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 8:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 9:
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
                _business.UpdateDoctor(ListDataIDs[i], input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]); //--Var

                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;

                _business.DeleteRelationDoctorHasHospitals(ListDataIDs[i]); //--Var

                if (listboxData.SelectedIndex != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            DoctorCode Doctor = _business.GetDoctors(sortingPar).Last(); //--Var
                            _business.AddHospitalToDoctor(Convert.ToInt16(l.Value), Doctor.Doctor_ID); //--Var
                        }
                    }
                }
                track1:
                continue;
            }
        }
        

        protected void BtnExit_Click(object sender,EventArgs e)
		{
            Response.Redirect("../Site/DoctorPage.aspx"); //--Var
        }

		protected void BtnSaveAndExit_Click(object sender,EventArgs e)
		{
            if (GetSessionDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            
            Response.Redirect("../Site/DoctorPage.aspx"); //--Var
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
            }
            
            Response.Redirect("../SiteEdit/DoctorPageEdit.aspx"); //--Var
        }
	}
}