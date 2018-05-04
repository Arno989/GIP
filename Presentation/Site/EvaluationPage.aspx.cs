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
            FillCRA();
            FillDoctor();
            FillStudyCoordinator();
        }

        protected void Edit(object sender, EventArgs e)
        {
            List<string> List1 = new List<string>();
            List<List<string>> ListData = new List<List<string>>();
            List<int> DataIDs = new List<int>();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        DataIDs.Add((int)GridView.DataKeys[i].Value);

                        for (int i2 = 1; i2 < GridView.Columns.Count; i2++)
                        {
                            List1.Add(GridView.Rows[i].Cells[i2].Text);
                        }
                        ListData.Add(List1);
                    }
                }
            }

            if (DataIDs.Count != 0)
            {
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

        public void FillCRA()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
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

                GridView.Rows[i].Cells[7].Text = CRAName;
            }
        }

        public void FillDoctor()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //Doctor ID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
                List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
                int DoctorID = CurrentEvaluation[0].CraID;

                //Doctor ID omzetten naar CRA name
                string sortingPar2 = string.Format(" WHERE Doctor_ID = {0}", DoctorID);
                List<DoctorCode> DoctorRelation = new List<DoctorCode>();
                DoctorRelation = _businesscode.GetDoctors(sortingPar2);
                string DoctorName = DoctorRelation[0].Name;

                GridView.Rows[i].Cells[8].Text = DoctorName;
            }
        }

        public void FillStudyCoordinator()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //Doctor ID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", GridView.DataKeys[i].Value);
                List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
                int StudyCoordinatorID = CurrentEvaluation[0].CraID;

                //Doctor ID omzetten naar CRA name
                string sortingPar2 = string.Format(" WHERE Doctor_ID = {0}", StudyCoordinatorID);
                List<StudyCoordinatorCode> StudyCoordinatorRelation = new List<StudyCoordinatorCode>();
                StudyCoordinatorRelation = _businesscode.GetStudyCoordinators(sortingPar2);
                string StudyCoordinatorName = StudyCoordinatorRelation[0].Name;

                GridView.Rows[i].Cells[9].Text = StudyCoordinatorName;
            }
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/EvaluationPageEdit.aspx");
        }
    }
}