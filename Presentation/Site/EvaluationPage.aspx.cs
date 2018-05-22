using System;
using System.Collections.Generic;
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
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetEvaluations(sortingPar);
                GridView.DataBind();
            }
            FillDropdown();
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

            if (DataIDs.Count != 0)
            {
                Session["ListTypes"] = ListTypes;
                Session["ListNames"] = ListNames;
                Session["DataID"] = DataIDs;
                Session["ListDataSession"] = ListData;
                Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to edit.')", true);
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
                        _businesscode.DeleteEvaluation(Convert.ToInt32(id));
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
                else if (CurrentEvaluation[0].DoctoID != -1)
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

            GridView.Rows[i].Cells[1].Text = "CRA";
            GridView.Rows[i].Cells[2].Text = CRAName;
        }
        public void FillDoctor(int i)
        {
            //Doctor ID krijgen van de current row in de gridvieuw
            string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
            List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
            CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
            int DoctorID = CurrentEvaluation[0].DoctoID;

            //Doctor ID omzetten naar CRA name
            string sortingPar2 = string.Format(" WHERE Doctor_ID = {0}", DoctorID);
            List<DoctorCode> DoctorRelation = new List<DoctorCode>();
            DoctorRelation = _businesscode.GetDoctors(sortingPar2);
            string DoctorName = DoctorRelation[0].Name;

            GridView.Rows[i].Cells[1].Text = "Doctor";
            GridView.Rows[i].Cells[2].Text = DoctorName;
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

            GridView.Rows[i].Cells[1].Text = "StudyCoordinator";
            GridView.Rows[i].Cells[2].Text = StudyCoordinatorName;
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
        }
    }
}