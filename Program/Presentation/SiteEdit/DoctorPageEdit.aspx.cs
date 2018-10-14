using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
    public partial class DoctorPageEdit : System.Web.UI.Page
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

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserCode user = (UserCode) Session["authenticatedUser"];
            if (user == null)
            {
                Response.Redirect("../index.aspx");
            }
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
                for (int i = 0; i <= 9; i++)
                {
                    List<List<string>> ListDropdownContent = _business.GetHospitalDropDownContent(); //--Var
                    List<string> Names = new List<string>();

                    string lbEdit = "lbEdit" + i.ToString() + "0";
                    var container = Master.FindControl("Body");
                    var DropDownData = container.FindControl(lbEdit) as ListBox;

                    for (int i2 = 0; i2 < ListDropdownContent.Count; i2++)
                    {
                        Names.Add(ListDropdownContent[i2][1]);
                    }
                    DropDownData.DataSource = Names;
                    DropDownData.DataBind();

                    for (int i2 = 0; i2 < ListDropdownContent.Count; i2++)
                    {
                        DropDownData.Items[i2].Value = ListDropdownContent[i2][0];
                    }
                }
            }
        }


        private void InsertData()
        {
            List<List<string>> ListDataSession = GetSessionData();
            var container = Master.FindControl("Body");

            for (int i = 0; i < ListDataSession.Count; i++)
            {
                for (int i2 = 0; i2 <= 9; i2++) //--Var
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    ((TextBox)txtBox).Text = ListDataSession[i][i2].Replace("&nbsp;", "");

                }

                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;

                List<int> IdSubject = GetSessionDataIDs();
                List<int> IdRel = _business.GetRelationDoctorHasHospitals(IdSubject[i]); //--Var

                if (IdRel.Count > 0)
                {
                    foreach (int IdRel1 in IdRel)
                    {
                        ListItem li = new ListItem();

                        li = listboxData.Items.FindByValue(IdRel1.ToString());
                        li.Selected = true;
                    }
                    IdRel.Clear();
                }
            }
        }

        private void SendData()
        {
            for (int i = 0; i < 10; i++)
            {
                var container = Master.FindControl("Body");
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 9; i2++) //--Var
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

                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
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
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
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
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            break;

                        case 7:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            break;

                        case 8:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
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

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.AddDoctor(new DoctorCode(0, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow))); //--Var

                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            DoctorCode doctor = _business.GetDoctors(sortingPar).Last(); //--Var
                            _business.AddHospitalToDoctor(Convert.ToInt32(l.Value.ToString()), doctor.ID); //--Var
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

                for (int i2 = 0; i2 <= 9; i2++) //--Var
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

                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
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
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
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
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            break;

                        case 7:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            break;

                        case 8:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
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

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.UpdateDoctor(new DoctorCode(ListDataIDs[i], input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow))); //--Var

                string lbName = "lbEdit" + i.ToString() + "0";
                var listboxData = container.FindControl(lbName) as ListBox;

                _business.DeleteRelationDoctorHasHospitals(ListDataIDs[i]); //--Var

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            _business.AddHospitalToDoctor(Convert.ToInt32(l.Value), ListDataIDs[i]); //--Var
                        }
                    }
                }
                track1:
                continue;
            }
        }


        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/DoctorPage.aspx"); //--Var
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

            Response.Redirect("../Site/DoctorPage.aspx"); //--Var
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
                Response.Redirect("../SiteEdit/DoctorPageEdit.aspx"); //--Var
            }
        }
    }
}