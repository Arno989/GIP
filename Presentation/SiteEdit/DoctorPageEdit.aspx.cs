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
            SetDropdownContent();
            SetListBoxContent();
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
            var container = Master.FindControl("Body");
            int Count = 0;
            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 9; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
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

                        case 8:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 9:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;
                    }
                    Count++;
                }

                //---------------------------------------------WIP--------------------

                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                List<int> IDDoctor = GetDataIDs();
                List<int> HospitalID = _business.GetRelationHospitalHasDoctor(IDDoctor[i]);
                if (HospitalID.Count > 0)
                {

                    ListItem li = dropdownData.Items.FindByValue(HospitalID[0].ToString());
                    dropdownData.ClearSelection();
                    li.Selected = true;
                    HospitalID.Clear();

                }
            }
        }

        private void SendData()
        {

            var container = Master.FindControl("Body");
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[10];
                //int Hospital_ID;

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
                _business.SetDoctor(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]);


                //-----------------------------------------WIP---------------------
                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;
                
                if (listboxData.SelectedIndex != 0)
                {
                    foreach (ListItem listItem in listboxData.Items)
                    {
                        if (listItem.Selected == true)
                        {
                            DoctorCode doctor = _business.GetDoctors(sortingPar).Last();
                            _business.addHospitalToDoctor(Convert.ToInt16(listboxData.SelectedValue), doctor.Doctor_ID);
                        }
                    }
                }
                track1:
                continue;
            }
        }

        private void UpdateData()
        {
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
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
                _business.UpdateDoctor(ListDataIDs[i], input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9]);

                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                List<int> OldHospitalID = _business.GetRelationHospitalHasDoctor(ListDataIDs[i]);
                int index = dropdownData.SelectedIndex;

                if (OldHospitalID.Count == 0 && index != 0)
                {
                    _business.addHospitalToDoctor(Convert.ToInt16(ListContentHospital[index - 1][0]), ListDataIDs[i]);
                }
                else if (dropdownData != null && OldHospitalID.Count != 0 && index != 0)
                {
                    _business.UpdateRelationHospitalHasDoctor(Convert.ToInt16(ListContentHospital[index - 1][0]), ListDataIDs[i], OldHospitalID[0]);
                    OldHospitalID.Clear();
                }
                else if (OldHospitalID.Count != 0)
                {
                    _business.DeleteRelationHospitalHasDoctor(OldHospitalID[0], ListDataIDs[i]);
                }
                track1:
                continue;
            }
        }


        public void SetDropdownContent()
        {
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            List<string> names = new List<string>();

            for (int i = 0; i <= 9; i++)
            {
                string ddEdit = "ddEdit" + i.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDownData = container.FindControl(ddEdit) as DropDownList;
                for(int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    if (i == 0)
                    {
                        names.Add(ListContentHospital[i2][1]);
                    }
                    else
                    {
                        goto track1;
                    }
                }
                track1:
                DropDownData.DataSource = names;
                DropDownData.DataBind();
                for (int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    DropDownData.Items[i2 + 1].Value = ListContentHospital[i2][0];
                }
            }
        }

        public void SetListBoxContent()
        {
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            List<string> names = new List<string>();
            
            
                string ddEdit = "lbEdit" + 0.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDownData = container.FindControl(ddEdit) as ListBox;
                for (int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    if (0 == 0)
                    {
                        names.Add(ListContentHospital[i2][1]);
                    }
                    else
                    {
                        goto track1;
                    }
                }
                track1:
                DropDownData.DataSource = names;
                DropDownData.DataBind();
            

                for (int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    if (i2 <= 9)
                    {
                        DropDownData.Items[i2 + 1].Value = ListContentHospital[i2][0];
                    }
                }
            
            
        }
        

        protected void btnExit_Click(object sender,EventArgs e)
		{
            Response.Redirect("../Site/DoctorPage.aspx");
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
            
            Response.Redirect("../Site/DoctorPage.aspx");
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
            
            Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
        }
	}
}