using System;
using System.Collections.Generic;
using System.Globalization;
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
                SetListBox1Content();
                SetListBox2Content();
                SetListBox3Content();
                SetListBox4Content();

                List<List<string>> ListData = GetData();
                if (ListData != null)
                {
                    InsertData();
                }

                Session["ListDataSession"] = null;
            }
        }

        public void SetListBox1Content()
        {
            if (!IsPostBack)
            {
                for (int i = 0; i <= 9; i++)
                {
                    List<List<string>> ListDropdownContent = _business.GetCRADropDownContent(); //--Var
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

        public void SetListBox2Content()
        {
            if (!IsPostBack)
            {
                for (int i = 0; i <= 9; i++)
                {
                    List<List<string>> ListDropdownContent = _business.GetDoctorDropDownContent(); //--Var
                    List<string> Names = new List<string>();

                    string lbEdit = "lbEdit" + i.ToString() + "1";
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

        public void SetListBox3Content()
        {
            if (!IsPostBack)
            {
                for (int i = 0; i <= 9; i++)
                {
                    List<List<string>> ListDropdownContent = _business.GetHospitalDropDownContent(); //--Var
                    List<string> Names = new List<string>();

                    string lbEdit = "lbEdit" + i.ToString() + "2";
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

        public void SetListBox4Content()
        {
            if (!IsPostBack)
            {
                for (int i = 0; i <= 9; i++)
                {
                    List<List<string>> ListDropdownContent = _business.GetProjectManagerDropDownContent(); //--Var
                    List<string> Names = new List<string>();

                    string lbEdit = "lbEdit" + i.ToString() + "3";
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
            List<List<string>> ListData = GetData();
            int count = 0;

            for (int i = 0; i < ListData.Count; i++)
            {
                List<int> IdSubject = GetDataIDs();
                string lbName;
                var listboxData = new ListBox();
                List<int> IdRel = new List<int>();
                var container = Master.FindControl("Body");

                for (int i2 = 0; i2 <= 2; i2++) //--Var
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
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
                            dateTime = DateTime.ParseExact(CurrentContract[0].End_Date, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            ((TextBox)txtBox).Text = dateTime.ToString("yyyy-MM-dd");
                            break;

                        case 2:
                            dateTime = DateTime.ParseExact(CurrentContract[0].End_Date, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            ((TextBox)txtBox).Text = dateTime.ToString("yyyy-MM-dd");
                            break;
                    }
                }
                                
                lbName = "lbEdit" + i.ToString() + "0";
                listboxData = container.FindControl(lbName) as ListBox;
                IdRel = _business.GetRelationProjectHasCRAs(IdSubject[i]); //--Var

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

                lbName = "lbEdit" + i.ToString() + "1";
                listboxData = container.FindControl(lbName) as ListBox;
                IdRel = _business.GetRelationProjectHasDoctors(IdSubject[i]); //--Var

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

                lbName = "lbEdit" + i.ToString() + "2";
                listboxData = container.FindControl(lbName) as ListBox;
                IdRel = _business.GetRelationProjectHasHospitals(IdSubject[i]); //--Var

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

                lbName = "lbEdit" + i.ToString() + "3";
                listboxData = container.FindControl(lbName) as ListBox;
                IdRel = _business.GetRelationProjectHasProjectManagers(IdSubject[i]); //--Var

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
                string lbName;
                var listboxData = new ListBox();

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
                                input[i2] = DateTime.Today.ToString();
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
                    }
                }
                _business.SetProject(input[0], Convert.ToDateTime(input[1]), Convert.ToDateTime(input[2])); //--Var

                lbName = "lbEdit" + i.ToString() + "0";
                listboxData = container.FindControl(lbName) as ListBox;

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            ProjectCode Project = _business.GetProjects(sortingPar).Last(); //--Var
                            _business.AddCRAToProject(Convert.ToInt32(l.Value.ToString()), Project.Project_ID); //--Var
                        }
                    }
                }

                lbName = "lbEdit" + i.ToString() + "1";
                listboxData = container.FindControl(lbName) as ListBox;

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            ProjectCode Project = _business.GetProjects(sortingPar).Last(); //--Var
                            _business.AddDoctorToProject(Convert.ToInt32(l.Value.ToString()), Project.Project_ID); //--Var
                        }
                    }
                }

                lbName = "lbEdit" + i.ToString() + "2";
                listboxData = container.FindControl(lbName) as ListBox;

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            ProjectCode Project = _business.GetProjects(sortingPar).Last(); //--Var
                            _business.AddHospitalToProject(Convert.ToInt32(l.Value.ToString()), Project.Project_ID); //--Var
                        }
                    }
                }

                lbName = "lbEdit" + i.ToString() + "3";
                listboxData = container.FindControl(lbName) as ListBox;

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            ProjectCode Project = _business.GetProjects(sortingPar).Last(); //--Var
                            _business.AddProjectManagerToProject(Convert.ToInt32(l.Value.ToString()), Project.Project_ID); //--Var
                        }
                    }
                }

                track1:
                continue;
            }
        }

        private void UpdateData()
        {
            string lbName;
            var listboxData = new ListBox();

            List<int> ListDataIDs = GetDataIDs();

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
                                input[i2] = DateTime.Today.ToString();
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
                    }
                }
                _business.UpdateProject(ListDataIDs[i], input[0], Convert.ToDateTime(input[1]), Convert.ToDateTime(input[2])); //--Var

                lbName = "lbEdit" + i.ToString() + "0";
                listboxData = container.FindControl(lbName) as ListBox;

                _business.DeleteRelationProjectHasCRAs(ListDataIDs[i]); //--Var

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            _business.AddCRAToProject(Convert.ToInt32(l.Value), ListDataIDs[i]); //--Var
                        }
                    }
                }

                lbName = "lbEdit" + i.ToString() + "1";
                listboxData = container.FindControl(lbName) as ListBox;

                _business.DeleteRelationProjectHasDoctors(ListDataIDs[i]); //--Var

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            _business.AddDoctorToProject(Convert.ToInt32(l.Value), ListDataIDs[i]); //--Var
                        }
                    }
                }

                lbName = "lbEdit" + i.ToString() + "2";
                listboxData = container.FindControl(lbName) as ListBox;

                _business.DeleteRelationProjectHasHospitals(ListDataIDs[i]); //--Var

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            _business.AddHospitalToProject(Convert.ToInt32(l.Value), ListDataIDs[i]); //--Var
                        }
                    }
                }

                lbName = "lbEdit" + i.ToString() + "3";
                listboxData = container.FindControl(lbName) as ListBox;

                _business.DeleteRelationProjectHasProjectManagers(ListDataIDs[i]); //--Var

                if (listboxData.SelectedIndex.ToString().Count() != 0)
                {
                    foreach (ListItem l in listboxData.Items)
                    {
                        if (l.Selected == true)
                        {
                            _business.AddProjectManagerToProject(Convert.ToInt32(l.Value), ListDataIDs[i]); //--Var
                        }
                    }
                }
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
            if (GetDataIDs() != null)
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
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
                Response.Redirect("../SiteEdit/ProjectPageEdit.aspx");  //--Var
            }
        }
    }
}