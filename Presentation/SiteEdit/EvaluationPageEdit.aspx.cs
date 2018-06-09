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
	public partial class EvaluationPageEdit: System.Web.UI.Page
	{
		private BusinessCode _business = new BusinessCode();
        string sortingPar = "";

        private List<List<string>> GetData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<string> GetTypes()
        {
            return (List<string>)Session["ListTypes"];
        }

        private List<string> GetNames()
        {
            return (List<string>)Session["ListNames"];
        }

        private List<int> GetDataIDs()
        {
            return (List<int>)Session["DataID"];
        }


        private void SendData()
		{
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[6];
                var container = Master.FindControl("Body");

                for (int i2 = 0; i2 <= 5; i2++)
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
                    }
                }

                List<List<string>> ListContentCRA = _business.GetCRADropDownContent();
                List<List<string>> ListContentDoctor = _business.GetDoctorDropDownContent();
                List<List<string>> ListContentSC = _business.GetStudyCoordinatorDropDownContent();
                List<string> Empty = new List<string>();
                Empty.Add(string.Empty);
                List<List<string>> ListAll = new List<List<string>>();

                ListAll.Add(Empty);
                ListAll.Add(Empty);
                for (int i3 = 0; i3 < ListContentCRA.Count; i3++)
                {
                    ListAll.Add(ListContentCRA[i3]);
                }
                ListAll.Add(Empty);
                for (int i3 = 0; i3 < ListContentDoctor.Count; i3++)
                {
                    ListAll.Add(ListContentDoctor[i3]);
                }
                ListAll.Add(Empty);
                for (int i3 = 0; i3 < ListContentSC.Count; i3++)
                {
                    ListAll.Add(ListContentSC[i3]);
                }

                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                string value = dropdownData.SelectedValue;
                string name = dropdownData.SelectedItem.Text;

                if (value.Contains("CR") == true)
                {
                    int valueInt = Convert.ToInt16(value.Remove(0, 2));
                    _business.SetEvaluation(Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], valueInt, -1, -1);
                }
                else if (value.Contains("DR") == true)
                {
                    int valueInt = Convert.ToInt16(value.Remove(0, 2));
                    _business.SetEvaluation(Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], -1, valueInt, -1);
                }
                else if (value.Contains("SC") == true)
                {
                    int valueInt = Convert.ToInt16(value.Remove(0, 2));
                    _business.SetEvaluation(Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], -1, -1, valueInt);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Make sure you have selected a valid relation.')", true);
                }

                ListContentCRA.Clear();
                ListContentDoctor.Clear();
                ListContentSC.Clear();
                ListAll.Clear();

                track1:
                continue;
            }
		}

        public void UpdateData()
        {
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[6];
                var container = Master.FindControl("Body");

                for (int i2 = 0; i2 <= 5; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + (i2).ToString();
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
                            input[i2] = (((TextBox)txtBox).Text.ToString()).Replace("&nbsp;", "");
                            break;

                        case 2:
                            input[i2] = (((TextBox)txtBox).Text.ToString()).Replace("&nbsp;", "");                            
                            break;

                        case 3:
                            input[i2] = (((TextBox)txtBox).Text.ToString()).Replace("&nbsp;", "");                            
                            break;

                        case 4:
                            input[i2] = (((TextBox)txtBox).Text.ToString()).Replace("&nbsp;", "");                            
                            break;

                        case 5:
                            input[i2] = (((TextBox)txtBox).Text.ToString()).Replace("&nbsp;", "");                            
                            break;
                    }
                }


                string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GetDataIDs()[i]);
                List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                CurrentEvaluation = _business.GetEvaluations(sortingPar1);

                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                string value = dropdownData.SelectedValue;

                if (value.Contains("CR") == true)
                {
                    int valueInt = Convert.ToInt16(value.Remove(0, 2));
                    _business.UpdateEvaluation(ListDataIDs[i], Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], (-1).ToString(), (-1).ToString(), valueInt.ToString());
                }
                else if (value.Contains("DR") == true)
                {
                    int valueInt = Convert.ToInt16(value.Remove(0, 2));
                    _business.UpdateEvaluation(ListDataIDs[i], Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], (-1).ToString(), valueInt.ToString(), (-1).ToString());
                }
                else if (value.Contains("SC") == true)
                {
                    int valueInt = Convert.ToInt16(value.Remove(0, 2));
                    _business.UpdateEvaluation(ListDataIDs[i], Convert.ToDateTime(input[0]), input[1], input[2], input[3], input[4], input[5], valueInt.ToString(), (-1).ToString(), (-1).ToString());
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Make sure you have selected a valid relation.')", true);
                }
                track1:
                continue;
            }
        }

        private void InsertData()
        {
            List<List<string>> ListData = GetData();
            List<string> ListTypes = GetTypes();
            List<string> ListNames = GetNames();
            var container = Master.FindControl("Body");
            int Count = 0;
            DateTime dateTime = DateTime.Today;

            for (int i = 0; i < ListData.Count; i++)
            {

                sortingPar = string.Format(" WHERE Evaluation_ID = {0}", GetDataIDs()[i]);
                List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                CurrentEvaluation = _business.GetEvaluations(sortingPar);

                for (int i2 = 0; i2 <= 6; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            dateTime = DateTime.ParseExact(CurrentEvaluation[0].Date, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            ((TextBox)txtBox).Text = dateTime.ToString("yyyy-MM-dd");
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
                    }
                        Count++;
                }
                string ddName = "ddEdit" + i.ToString() + 0.ToString();
                var dd = container.FindControl(ddName) as DropDownList;

                if (i < ListTypes.Count)
                {
                    if (ListTypes[i] == "CRA")
                    {
                        //CRA ID krijgen van de current row in de gridvieuw
                        int CRAID = CurrentEvaluation[0].CraID;

                        //de CRA selecteren in de dropdown
                        ListItem li = dd.Items.FindByValue("CR" + CRAID.ToString());
                        if (li.Text == ListNames[i])
                        {
                            dd.ClearSelection();
                            li.Selected = true;
                        }
                    }

                    if (ListTypes[i] == "Doctor")
                    {
                        //Doctor ID krijgen van de current row in de gridvieuw
                        int DoctorID = CurrentEvaluation[0].DoctorID;

                        //de Doctor selecteren in de dropdown
                        ListItem li = dd.Items.FindByValue("DR" + DoctorID.ToString());
                        if (li.Text == ListNames[i])
                        {
                            dd.ClearSelection();
                            li.Selected = true;
                        }
                    }

                    if (ListTypes[i] == "StudyCoordinator")
                    {
                        //SC ID krijgen van de current row in de gridvieuw
                        int SCID = CurrentEvaluation[0].ScID;

                        //de SC selecteren in de dropdown
                        ListItem li = dd.Items.FindByValue("SC" + SCID.ToString());
                        if (li.Text == ListNames[i])
                        {
                            dd.ClearSelection();
                            li.Selected = true;
                        }
                    }
                }
            }
        }


        public void SetDropdownContent()
        {
            List<List<string>> ListContentCRA = _business.GetCRADropDownContent();
            List<List<string>> ListContentDoctor = _business.GetDoctorDropDownContent();
            List<List<string>> ListContentStudyCoordinator = _business.GetStudyCoordinatorDropDownContent();
            List<string> names = new List<string>();
            int count = 1;

            if (ListContentCRA.Count > 0)
            {
                names.Add("----CRA's");
                for (int i2 = 0; i2 < ListContentCRA.Count; i2++)
                {
                    if (count % 2 != 0)
                    {
                        names.Add(ListContentCRA[i2][1]);
                    }
                    count = count + 2;
                }
                count = 1;
            }

            if (ListContentDoctor.Count > 0)
            {
                names.Add("----Doctors");
                for (int i2 = 0; i2 < ListContentDoctor.Count; i2++)
                {
                    if (count % 2 != 0)
                    {
                        names.Add(ListContentDoctor[i2][1]);
                    }
                    count = count + 2;
                }
                count = 1;
            }

            if (ListContentStudyCoordinator.Count > 0)
            {
                names.Add("----Study Coördinators");
                for (int i2 = 0; i2 < ListContentStudyCoordinator.Count; i2++)
                {
                    if (count % 2 != 0)
                    {
                        names.Add(ListContentStudyCoordinator[i2][1]);
                    }
                    count = count + 2;
                }
                count = 1;
            }

            for (int i = 0; i <= 9; i++)
            {
                string ddEdit = "ddEdit" + i.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDown = container.FindControl(ddEdit) as DropDownList;
                DropDown.DataSource = names;
                DropDown.DataBind();

                int StartCRA = 2;
                int StartDoctor = StartCRA + ListContentCRA.Count + 1;
                int StartSC = StartDoctor + ListContentDoctor.Count + 1;
                int total = StartSC + ListContentStudyCoordinator.Count;

                int count1 = 0;

                for (int i2 = 2; i2  < ListContentCRA.Count + 2; i2++)
                {
                    DropDown.Items[i2].Value = "CR" + ListContentCRA[count1][0];
                    count1++;
                }
                count1 = 0;
                for(int i2 = StartDoctor; i2 < StartDoctor + ListContentDoctor.Count; i2++)
                {
                    DropDown.Items[i2].Value = "DR" + ListContentDoctor[count1][0];
                    count1++;
                }
                count1 = 0;
                for(int i2 = StartSC; i2 < StartSC + ListContentStudyCoordinator.Count; i2++)
                {
                    DropDown.Items[i2].Value = "SC" + ListContentStudyCoordinator[count1][0];
                    //DropDown.Items[i2].Attributes.Add("disabled", "disables");
                    count1++;
                }
                DropDown.Items[1].Attributes.Add("disabled", "disables");
                DropDown.Items[1+ ListContentCRA.Count+1].Attributes.Add("disabled", "disables");
                DropDown.Items[1+ListContentCRA.Count+1+ListContentDoctor.Count+1].Attributes.Add("disabled", "disables");
            }

            
        }


        protected void Page_Load(object sender,EventArgs e)
		{
            SetDropdownContent();
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


		protected void BtnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/EvaluationPage.aspx");
		}

		protected void BtnSaveAndExit_Click(object sender,EventArgs e)
		{
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/EvaluationPage.aspx");
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
                Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
            }
		}
	}
}