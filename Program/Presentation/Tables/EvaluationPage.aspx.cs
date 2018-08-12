using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class EvaluationPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Date ASC";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack || !IsPostBack)
            {
                UserCode user = (UserCode) Session["authenticatedUser"];
                if (user == null)
                {
                    Response.Redirect("/index.aspx");
                }
            }
            if (!IsPostBack)
            {
                Load_content();
            }
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _businesscode.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        protected void Load_content()
        {
            GridView.DataSource = _businesscode.GetEvaluations(sortingPar);
            GridView.DataBind();
            FillDropdown();
            FillLabel();
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
        }

        protected void Edit(object sender, EventArgs e)
        {
            List<string> List1 = new List<string>();
            List<List<string>> ListData = new List<List<string>>();
            List<int> DataIDs = new List<int>();
            List<string> ListTypes = new List<string>();
            List<string> ListNames = new List<string>();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        DataIDs.Add((int)GridView.DataKeys[i].Value);

                        for (int i2 = 3; i2 < GridView.Columns.Count; i2++)
                        {
                            List1.Add(GridView.Rows[i].Cells[i2].Text);
                        }
                        ListTypes.Add(GridView.Rows[i].Cells[1].Text);
                        ListNames.Add(GridView.Rows[i].Cells[2].Text);
                        ListData.Add(new List<string>(List1));
                        List1.Clear();
                    }
                }
            }

            if (DataIDs.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to edit.')", true);

            }
            else if (DataIDs.Count > 10)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('You cannot edit more than 10 records at a time.')", true);
            }
            else
            {
                Session["ListTypes"] = ListTypes;
                Session["ListNames"] = ListNames;
                Session["DataID"] = DataIDs;
                Session["ListDataSession"] = ListData;
                Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            bool CheckedOrNot = false;
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        int id = (int)GridView.DataKeys[i].Value;
                        _businesscode.DeleteEvaluation(Convert.ToInt32(id), "");
                        CheckedOrNot = true;
                    }
                }
            }

            if (CheckedOrNot == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to delete.')", true);
            }
            else
            {
                Response.Redirect("../Site/EvaluationPage.aspx");
            }
        }
        
        public void FillDropdown()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
                List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
                if(CurrentEvaluation[0].CraID != -1)
                {
                    FillCRA(i);
                }
                else if (CurrentEvaluation[0].DoctorID != -1)
                {
                    FillDoctor(i);
                }
                else if (CurrentEvaluation[0].ScID != -1)
                {
                    FillStudyCoordinator(i);
                }
            }
        }

        public void FillCRA(int i)
        {
            //CRA ID krijgen van de current row in de gridvieuw
            string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
            List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
            CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
            int CRAID = CurrentEvaluation[0].CraID;

            //CRA ID omzetten naar CRA name
            string sortingPar2 = string.Format(" WHERE CRA_ID = {0}", CRAID);
            List<CRACode> CRARelation = new List<CRACode>();
            CRARelation = _businesscode.GetCRAs(sortingPar2);
            string CRAName = CRARelation[0].Name;

            GridView.Rows[i].Cells[0].Text = "CRA";
            GridView.Rows[i].Cells[1].Text = CRAName;
        }

        public void FillDoctor(int i)
        {
            //Doctor ID krijgen van de current row in de gridvieuw
            string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
            List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
            CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
            int DoctorID = CurrentEvaluation[0].DoctorID;

            //Doctor ID omzetten naar CRA name
            string sortingPar2 = string.Format(" WHERE Doctor_ID = {0}", DoctorID);
            List<DoctorCode> DoctorRelation = new List<DoctorCode>();
            DoctorRelation = _businesscode.GetDoctors(sortingPar2);
            string DoctorName = DoctorRelation[0].Name;

            GridView.Rows[i].Cells[0].Text = "Doctor";
            GridView.Rows[i].Cells[1].Text = DoctorName;
        }

        public void FillStudyCoordinator(int i)
        {
            //Doctor ID krijgen van de current row in de gridvieuw
            string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
            List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
            CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
            int StudyCoordinatorID = CurrentEvaluation[0].ScID;

            //Doctor ID omzetten naar CRA name
            string sortingPar2 = string.Format(" WHERE StudyCoordinator_ID = {0}", StudyCoordinatorID);
            List<StudyCoordinatorCode> StudyCoordinatorRelation = new List<StudyCoordinatorCode>();
            StudyCoordinatorRelation = _businesscode.GetStudyCoordinators(sortingPar2);
            string StudyCoordinatorName = StudyCoordinatorRelation[0].Name;

            GridView.Rows[i].Cells[0].Text = "Study Coordinator";
            GridView.Rows[i].Cells[1].Text = StudyCoordinatorName;
        }

        public void FillLabel()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
                List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
                
                GridView.Rows[i].Cells[7].BackColor = Color.FromName(CurrentEvaluation[0].Label);
                GridView.Rows[i].Cells[7].ForeColor = Color.FromName(CurrentEvaluation[0].Label);
                GridView.Rows[i].Cells[7].Text = CurrentEvaluation[0].Label;
            }
        }

        protected void Sort(object sender, GridViewSortEventArgs e)
        {
            if (e.SortDirection.ToString() == "Ascending")
            {
                string sort = "ORDER BY " + e.SortExpression + " " + GetSortDirection(e.SortExpression);
                sortingPar = sort;
                
                if (e.SortExpression == "Date")
                {
                    ViewState.Add("Sorting", "Date");
                }
                else if (e.SortExpression == "Feedback")
                {
                    ViewState.Add("Sorting", "Feedback");
                }
                else if (e.SortExpression == "Accuracy")
                {
                    ViewState.Add("Sorting", "Accuracy");
                }
                else if (e.SortExpression == "Quality")
                {
                    ViewState.Add("Sorting", "Quality");
                }
                else if (e.SortExpression == "Evaluation_Text")
                {
                    ViewState.Add("Sorting", "Evaluation");
                }
                else if (e.SortExpression == "Label")
                {
                    ViewState.Add("Sorting", "Label");
                }

                Load_content();
            }
        }

        protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                string imgAsc = @" <img src='..\Images\round_arrow_drop_up_black_18dp.png' title='Ascending' />";
                string imgDes = @" <img src='..\Images\round_arrow_drop_down_black_18dp.png' title='Descendng' />";

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        LinkButton lnkbtn = (LinkButton)e.Row.Cells[3].Controls[0];
                        try
                        {
                            lnkbtn = (LinkButton)cell.Controls[0];
                        }
                        catch
                        {
                            goto track1;
                        }
                        track1:
                        if (lnkbtn.Text == ViewState["Sorting"].ToString())
                        {
                            if (ViewState["SortDirection"] as string == "ASC")
                            {
                                lnkbtn.Text += imgAsc;
                            }
                            else
                                lnkbtn.Text += imgDes;
                        }
                    }
                }
            }
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<EvaluationCode> _evaluation = new List<EvaluationCode>();
                _evaluation = _businesscode.GetEvaluations("where Evaluation_ID = " + GridView.DataKeys[e.Row.RowIndex].Value);

                for (int i = 1; i < GridView.Columns.Count; i++)
                {
                    if (user.Type == "Admin")
                    {
                        UserCode _user = _businesscode.GetUsers($"WHERE User_ID = {_evaluation[0].User_ID};")[0];
                        e.Row.ToolTip = "First added on " + _evaluation[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + _evaluation[0].Date_Last_Edited.ToString("dd-MMM-yyyy") + " by " + _user.Username;
                    }
                    else
                    {
                        e.Row.ToolTip = "First added on " + _evaluation[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + _evaluation[0].Date_Last_Edited.ToString("dd-MMM-yyyy");
                    }
                }
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";

            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

    }
}