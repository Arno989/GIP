using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class HomeSite: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Name ASC";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Buttons
        protected void ButtonCRA_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/CRAPage.aspx");
        }

        protected void ButtonClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ClientPage.aspx");
        }

        protected void ButtonContract_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ContractPage.aspx");
        }

        protected void ButtonDepartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/DepartmentPage.aspx");
        }

        protected void ButtonDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/DoctorPage.aspx");
        }

        protected void ButtonEvaluation_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/EvaluationPage.aspx");
        }

        protected void ButtonHospital_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/HospitalPage.aspx");
        }

        protected void ButtonProjectManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ProjectManagerPage.aspx");
        }

        protected void ButtonProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/ProjectPage.aspx");
        }

        protected void ButtonStudyCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/StudyCoordinatorPage.aspx");
        }
        #endregion
        
        protected void TbSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void DdTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void Search()
        {
            sortingPar = TbSearch.Text;

            rowCRAGrid.Visible = false;
            rowCRAText.Visible = false;

            rowClientGrid.Visible = false;
            rowClientText.Visible = false;

            rowContractGrid.Visible = false;
            rowContractText.Visible = false;

            rowDepartmentGrid.Visible = false;
            rowDepartmentText.Visible = false;

            rowDoctorGrid.Visible = false;
            rowDoctorText.Visible = false;

            rowEvaluationGrid.Visible = false;
            rowEvaluationText.Visible = false;

            rowHospitalGrid.Visible = false;
            rowHospitalText.Visible = false;

            rowProjectManagerGrid.Visible = false;
            rowProjectManagerText.Visible = false;

            rowProjectGrid.Visible = false;
            rowProjectText.Visible = false;

            rowStudyCoordinatorGrid.Visible = false;
            rowStudyCoordinatorText.Visible = false;

            if (TbSearch.Text.Trim() != "")
            {
                buttonTable.Visible = false;
                resultTable.Visible = true;
            }
            else
            {
                buttonTable.Visible = true;
                resultTable.Visible = false;
            }

            switch (ddTable.SelectedItem.Text.ToString())
            {
                case "All":
                    gvCRA.DataSource = _businesscode.SearchCRAs(sortingPar);
                    if (_businesscode.SearchCRAs(sortingPar).Count > 0)
                    {
                        gvCRA.DataBind();
                        rowCRAGrid.Visible = true;
                        rowCRAText.Visible = true;
                    }

                    gvClient.DataSource = _businesscode.SearchClients(sortingPar);
                    if (_businesscode.SearchClients(sortingPar).Count > 0)
                    {
                        gvClient.DataBind();
                        rowClientGrid.Visible = true;
                        rowClientText.Visible = true;
                    }

                    gvContract.DataSource = _businesscode.SearchContracts(sortingPar);
                    if (_businesscode.SearchContracts(sortingPar).Count > 0)
                    {
                        gvContract.DataBind();
                        rowContractGrid.Visible = true;
                        rowContractText.Visible = true;

                        for (int i = 0; i > gvContract.Rows.Count; i++)
                        {
                            //projectID krijgen van de current row in de gridvieuw
                            string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", gvContract.DataKeys[i].Value);
                            List<ContractCode> CurrentContract = new List<ContractCode>();
                            CurrentContract = _businesscode.GetContracts(sortingPar1);
                            int projectID = CurrentContract[0].ProjectID;

                            //projectID omzetten naar project title
                            string sortingPar2 = string.Format(" WHERE Project_ID = {0}", projectID);
                            List<ProjectCode> ProjectRelation = new List<ProjectCode>();
                            ProjectRelation = _businesscode.GetProjects(sortingPar2);
                            string ProjectTitle = ProjectRelation[0].Title;

                            gvContract.Rows[i].Cells[5].Text = ProjectTitle;
                        }

                        for (int i = 0; i > gvContract.Rows.Count; i++)
                        {
                            //projectID krijgen van de current row in de gridvieuw
                            string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", gvContract.DataKeys[i].Value);
                            List<ContractCode> CurrentContract = new List<ContractCode>();
                            CurrentContract = _businesscode.GetContracts(sortingPar1);
                            int clientID = CurrentContract[0].ClientID;

                            //projectID omzetten naar project title
                            string sortingPar2 = string.Format(" WHERE Client_ID = {0}", clientID);
                            List<ClientCode> ClientRelation = new List<ClientCode>();
                            ClientRelation = _businesscode.GetClients(sortingPar2);
                            string ClientName = ClientRelation[0].Name;

                            gvContract.Rows[i].Cells[6].Text = ClientName;
                        }
                    }

                    gvDepartment.DataSource = _businesscode.SearchDepartments(sortingPar);
                    if (_businesscode.SearchDepartments(sortingPar).Count > 0)
                    {
                        gvDepartment.DataBind();
                        rowDepartmentGrid.Visible = true;
                        rowDepartmentText.Visible = true;

                        for (int i = 0; i > gvDepartment.Rows.Count; i++)
                        {
                            //hospitalID krijgen van de current row in de gridvieuw
                            string sortingPar1 = string.Format(" WHERE Department_ID = {0}", gvDepartment.DataKeys[i].Value);
                            List<DepartmentCode> CurrentDepartment = new List<DepartmentCode>();
                            CurrentDepartment = _businesscode.GetDepartments(sortingPar1);
                            int hospitalID = CurrentDepartment[0].HospitalID;

                            // hospitalID omzetten naar hospital name
                            string sortingPar2 = string.Format(" WHERE Hospital_ID = {0}", hospitalID);
                            List<HospitalCode> HospitalRelation = new List<HospitalCode>();
                            HospitalRelation = _businesscode.GetHospitals(sortingPar2);
                            string hospitalName = HospitalRelation[0].Name;

                            gvDepartment.Rows[i].Cells[4].Text = hospitalName;
                        }
                    }

                    gvDoctor.DataSource = _businesscode.SearchDoctors(sortingPar);
                    if (_businesscode.SearchDoctors(sortingPar).Count > 0)
                    {
                        gvDoctor.DataBind();
                        rowDoctorGrid.Visible = true;
                        rowDoctorText.Visible = true;

                        for (int i = 0; i > gvDoctor.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel1";
                            ListBox listbox = gvDoctor.Rows[i].Cells[11].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationDoctorHasHospitals(Convert.ToInt32(gvDoctor.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<HospitalCode> RelRaw = new List<HospitalCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Hospital_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetHospitals(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }
                    }

                    gvEvaluation.DataSource = _businesscode.SearchEvaluations(sortingPar);
                    if (_businesscode.SearchEvaluations(sortingPar).Count > 0)
                    {
                        gvEvaluation.DataBind();
                        rowEvaluationGrid.Visible = true;
                        rowEvaluationText.Visible = true;

                        for (int i = 0; i > gvEvaluation.Rows.Count; i++)
                        {
                            string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", gvEvaluation.DataKeys[i].Value);
                            List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                            CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
                            if (CurrentEvaluation[0].CraID != -1)
                            {
                                int CRAID = CurrentEvaluation[0].CraID;

                                //CRA ID omzetten naar CRA name
                                string sortingPar2 = string.Format(" WHERE CRA_ID = {0}", CRAID);
                                List<CRACode> CRARelation = new List<CRACode>();
                                CRARelation = _businesscode.GetCRAs(sortingPar2);
                                string CRAName = CRARelation[0].Name;

                                gvEvaluation.Rows[i].Cells[1].Text = "CRA";
                                gvEvaluation.Rows[i].Cells[2].Text = CRAName;
                            }
                            else if (CurrentEvaluation[0].DoctorID != -1)
                            {
                                int DoctorID = CurrentEvaluation[0].DoctorID;

                                //Doctor ID omzetten naar CRA name
                                string sortingPar2 = string.Format(" WHERE Doctor_ID = {0}", DoctorID);
                                List<DoctorCode> DoctorRelation = new List<DoctorCode>();
                                DoctorRelation = _businesscode.GetDoctors(sortingPar2);
                                string DoctorName = DoctorRelation[0].Name;

                                gvEvaluation.Rows[i].Cells[1].Text = "Doctor";
                                gvEvaluation.Rows[i].Cells[2].Text = DoctorName;
                            }
                            else if (CurrentEvaluation[0].ScID != -1)
                            {
                                int StudyCoordinatorID = CurrentEvaluation[0].ScID;

                                //Doctor ID omzetten naar CRA name
                                string sortingPar2 = string.Format(" WHERE StudyCoordinator_ID = {0}", StudyCoordinatorID);
                                List<StudyCoordinatorCode> StudyCoordinatorRelation = new List<StudyCoordinatorCode>();
                                StudyCoordinatorRelation = _businesscode.GetStudyCoordinators(sortingPar2);
                                string StudyCoordinatorName = StudyCoordinatorRelation[0].Name;

                                gvEvaluation.Rows[i].Cells[1].Text = "StudyCoordinator";
                                gvEvaluation.Rows[i].Cells[2].Text = StudyCoordinatorName;
                            }
                        }
                    }

                    gvHospital.DataSource = _businesscode.SearchHospitals(sortingPar);
                    if (_businesscode.SearchHospitals(sortingPar).Count > 0)
                    {
                        gvHospital.DataBind();
                        rowHospitalGrid.Visible = true;
                        rowHospitalText.Visible = true;
                    }

                    gvProjectManager.DataSource = _businesscode.SearchProjectManagers(sortingPar);
                    if (_businesscode.SearchProjectManagers(sortingPar).Count > 0)
                    {
                        gvProjectManager.DataBind();
                        rowProjectManagerGrid.Visible = true;
                        rowProjectManagerText.Visible = true;
                    }

                    gvProject.DataSource = _businesscode.SearchProjects(sortingPar);
                    if (_businesscode.SearchProjects(sortingPar).Count > 0)
                    {
                        gvProject.DataBind();
                        rowProjectGrid.Visible = true;
                        rowProjectText.Visible = true;

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel1";
                            ListBox listbox = gvProject.Rows[i].Cells[4].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasCRAs(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<CRACode> RelRaw = new List<CRACode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE CRA_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetCRAs(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel2";
                            ListBox listbox = gvProject.Rows[i].Cells[5].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasDoctors(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<DoctorCode> RelRaw = new List<DoctorCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Doctor_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetDoctors(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel3";
                            ListBox listbox = gvProject.Rows[i].Cells[6].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasHospitals(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<HospitalCode> RelRaw = new List<HospitalCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Hospital_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetHospitals(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel4";
                            ListBox listbox = gvProject.Rows[i].Cells[7].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasProjectManagers(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<ProjectManagerCode> RelRaw = new List<ProjectManagerCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE ProjectManager_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetProjectManagers(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }
                    }

                    gvStudyCoordinator.DataSource = _businesscode.SearchStudyCoordinators(sortingPar);
                    if (_businesscode.SearchStudyCoordinators(sortingPar).Count > 0)
                    {
                        gvStudyCoordinator.DataBind();
                        rowStudyCoordinatorGrid.Visible = true;
                        rowStudyCoordinatorText.Visible = true;

                        for (int i = 0; i > gvStudyCoordinator.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel1";
                            ListBox listbox = gvStudyCoordinator.Rows[i].Cells[6].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationStudyCoordinatorHasDoctors(Convert.ToInt32(gvStudyCoordinator.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<DoctorCode> RelRaw = new List<DoctorCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Doctor_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetDoctors(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }
                    }
                    break;

                case "CRA":
                    gvCRA.DataSource = _businesscode.SearchCRAs(sortingPar);
                    if (_businesscode.SearchCRAs(sortingPar).Count > 0)
                    {
                        gvCRA.DataBind();
                        rowCRAGrid.Visible = true;
                        rowCRAText.Visible = true;
                    }
                    break;

                case "Client":
                    gvClient.DataSource = _businesscode.SearchClients(sortingPar);
                    if (_businesscode.SearchClients(sortingPar).Count > 0)
                    {
                        gvClient.DataBind();
                        rowClientGrid.Visible = true;
                        rowClientText.Visible = true;
                    }
                    break;

                case "Client Contract":
                    gvContract.DataSource = _businesscode.SearchContracts(sortingPar);
                    if (_businesscode.SearchContracts(sortingPar).Count > 0)
                    {
                        gvContract.DataBind();
                        rowContractGrid.Visible = true;
                        rowContractText.Visible = true;

                        for (int i = 0; i > gvContract.Rows.Count; i++)
                        {
                            //projectID krijgen van de current row in de gridvieuw
                            string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", gvContract.DataKeys[i].Value);
                            List<ContractCode> CurrentContract = new List<ContractCode>();
                            CurrentContract = _businesscode.GetContracts(sortingPar1);
                            int projectID = CurrentContract[0].ProjectID;

                            //projectID omzetten naar project title
                            string sortingPar2 = string.Format(" WHERE Project_ID = {0}", projectID);
                            List<ProjectCode> ProjectRelation = new List<ProjectCode>();
                            ProjectRelation = _businesscode.GetProjects(sortingPar2);
                            string ProjectTitle = ProjectRelation[0].Title;

                            gvContract.Rows[i].Cells[5].Text = ProjectTitle;
                        }

                        for (int i = 0; i > gvContract.Rows.Count; i++)
                        {
                            //projectID krijgen van de current row in de gridvieuw
                            string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", gvContract.DataKeys[i].Value);
                            List<ContractCode> CurrentContract = new List<ContractCode>();
                            CurrentContract = _businesscode.GetContracts(sortingPar1);
                            int clientID = CurrentContract[0].ClientID;

                            //projectID omzetten naar project title
                            string sortingPar2 = string.Format(" WHERE Client_ID = {0}", clientID);
                            List<ClientCode> ClientRelation = new List<ClientCode>();
                            ClientRelation = _businesscode.GetClients(sortingPar2);
                            string ClientName = ClientRelation[0].Name;

                            gvContract.Rows[i].Cells[6].Text = ClientName;
                        }
                    }
                    break;

                case "Department":
                    gvDepartment.DataSource = _businesscode.SearchDepartments(sortingPar);
                    if (_businesscode.SearchDepartments(sortingPar).Count > 0)
                    {
                        gvDepartment.DataBind();
                        rowDepartmentGrid.Visible = true;
                        rowDepartmentText.Visible = true;

                        for (int i = 0; i > gvDepartment.Rows.Count; i++)
                        {
                            //hospitalID krijgen van de current row in de gridvieuw
                            string sortingPar1 = string.Format(" WHERE Department_ID = {0}", gvDepartment.DataKeys[i].Value);
                            List<DepartmentCode> CurrentDepartment = new List<DepartmentCode>();
                            CurrentDepartment = _businesscode.GetDepartments(sortingPar1);
                            int hospitalID = CurrentDepartment[0].HospitalID;

                            // hospitalID omzetten naar hospital name
                            string sortingPar2 = string.Format(" WHERE Hospital_ID = {0}", hospitalID);
                            List<HospitalCode> HospitalRelation = new List<HospitalCode>();
                            HospitalRelation = _businesscode.GetHospitals(sortingPar2);
                            string hospitalName = HospitalRelation[0].Name;

                            gvDepartment.Rows[i].Cells[4].Text = hospitalName;
                        }
                    }
                    break;

                case "Doctor":
                    gvDoctor.DataSource = _businesscode.SearchDoctors(sortingPar);
                    if (_businesscode.SearchDoctors(sortingPar).Count > 0)
                    {
                        gvDoctor.DataBind();
                        rowDoctorGrid.Visible = true;
                        rowDoctorText.Visible = true;

                        for (int i = 0; i > gvDoctor.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel1";
                            ListBox listbox = gvDoctor.Rows[i].Cells[11].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationDoctorHasHospitals(Convert.ToInt32(gvDoctor.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<HospitalCode> RelRaw = new List<HospitalCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Hospital_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetHospitals(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }
                    }
                    break;

                case "Evaluation":
                    gvEvaluation.DataSource = _businesscode.SearchEvaluations(sortingPar);
                    if (_businesscode.SearchEvaluations(sortingPar).Count > 0)
                    {
                        gvEvaluation.DataBind();
                        rowEvaluationGrid.Visible = true;
                        rowEvaluationText.Visible = true;

                        for (int i = 0; i > gvEvaluation.Rows.Count; i++)
                        {
                            string sortingPar1 = string.Format(" WHERE Evaluation_ID = {0}", gvEvaluation.DataKeys[i].Value);
                            List<EvaluationCode> CurrentEvaluation = new List<EvaluationCode>();
                            CurrentEvaluation = _businesscode.GetEvaluations(sortingPar1);
                            if (CurrentEvaluation[0].CraID != -1)
                            {
                                int CRAID = CurrentEvaluation[0].CraID;

                                //CRA ID omzetten naar CRA name
                                string sortingPar2 = string.Format(" WHERE CRA_ID = {0}", CRAID);
                                List<CRACode> CRARelation = new List<CRACode>();
                                CRARelation = _businesscode.GetCRAs(sortingPar2);
                                string CRAName = CRARelation[0].Name;

                                gvEvaluation.Rows[i].Cells[1].Text = "CRA";
                                gvEvaluation.Rows[i].Cells[2].Text = CRAName;
                            }
                            else if (CurrentEvaluation[0].DoctorID != -1)
                            {
                                int DoctorID = CurrentEvaluation[0].DoctorID;

                                //Doctor ID omzetten naar CRA name
                                string sortingPar2 = string.Format(" WHERE Doctor_ID = {0}", DoctorID);
                                List<DoctorCode> DoctorRelation = new List<DoctorCode>();
                                DoctorRelation = _businesscode.GetDoctors(sortingPar2);
                                string DoctorName = DoctorRelation[0].Name;

                                gvEvaluation.Rows[i].Cells[1].Text = "Doctor";
                                gvEvaluation.Rows[i].Cells[2].Text = DoctorName;
                            }
                            else if (CurrentEvaluation[0].ScID != -1)
                            {
                                int StudyCoordinatorID = CurrentEvaluation[0].ScID;

                                //Doctor ID omzetten naar CRA name
                                string sortingPar2 = string.Format(" WHERE StudyCoordinator_ID = {0}", StudyCoordinatorID);
                                List<StudyCoordinatorCode> StudyCoordinatorRelation = new List<StudyCoordinatorCode>();
                                StudyCoordinatorRelation = _businesscode.GetStudyCoordinators(sortingPar2);
                                string StudyCoordinatorName = StudyCoordinatorRelation[0].Name;

                                gvEvaluation.Rows[i].Cells[1].Text = "StudyCoordinator";
                                gvEvaluation.Rows[i].Cells[2].Text = StudyCoordinatorName;
                            }
                        }
                    }
                    break;

                case "Hospital":
                    gvHospital.DataSource = _businesscode.SearchHospitals(sortingPar);
                    if (_businesscode.SearchHospitals(sortingPar).Count > 0)
                    {
                        gvHospital.DataBind();
                        rowHospitalGrid.Visible = true;
                        rowHospitalText.Visible = true;
                    }
                    break;

                case "Project Manager":
                    gvProjectManager.DataSource = _businesscode.SearchProjectManagers(sortingPar);
                    if (_businesscode.SearchProjectManagers(sortingPar).Count > 0)
                    {
                        gvProjectManager.DataBind();
                        rowProjectManagerGrid.Visible = true;
                        rowProjectManagerText.Visible = true;
                    }
                    break;

                case "Project":
                    gvProject.DataSource = _businesscode.SearchProjects(sortingPar);
                    if (_businesscode.SearchProjects(sortingPar).Count > 0)
                    {
                        gvProject.DataBind();
                        rowProjectGrid.Visible = true;
                        rowProjectText.Visible = true;

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel1";
                            ListBox listbox = gvProject.Rows[i].Cells[4].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasCRAs(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<CRACode> RelRaw = new List<CRACode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE CRA_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetCRAs(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel2";
                            ListBox listbox = gvProject.Rows[i].Cells[5].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasDoctors(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<DoctorCode> RelRaw = new List<DoctorCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Doctor_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetDoctors(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel3";
                            ListBox listbox = gvProject.Rows[i].Cells[6].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasHospitals(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<HospitalCode> RelRaw = new List<HospitalCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Hospital_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetHospitals(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }

                        for (int i = 0; i > gvProject.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel4";
                            ListBox listbox = gvProject.Rows[i].Cells[7].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationProjectHasProjectManagers(Convert.ToInt32(gvProject.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<ProjectManagerCode> RelRaw = new List<ProjectManagerCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE ProjectManager_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetProjectManagers(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }
                    }
                    break;

                case "Study Coordinator":
                    gvStudyCoordinator.DataSource = _businesscode.SearchStudyCoordinators(sortingPar);
                    if (_businesscode.SearchStudyCoordinators(sortingPar).Count > 0)
                    {
                        gvStudyCoordinator.DataBind();
                        rowStudyCoordinatorGrid.Visible = true;
                        rowStudyCoordinatorText.Visible = true;

                        for (int i = 0; i > gvStudyCoordinator.Rows.Count; i++)
                        {
                            var container = Master.FindControl("Body");
                            string lbName = "lbRel1";
                            ListBox listbox = gvStudyCoordinator.Rows[i].Cells[6].FindControl(lbName) as ListBox;
                            List<int> Relations = _businesscode.GetRelationStudyCoordinatorHasDoctors(Convert.ToInt32(gvStudyCoordinator.DataKeys[i].Value)); //--Var

                            if (Relations.Count != 0)
                            {
                                List<DoctorCode> RelRaw = new List<DoctorCode>(); //--Var

                                for (int i2 = 0; i2 < Relations.Count; i2++)
                                {
                                    sortingPar = string.Format("WHERE Doctor_ID = {0} ORDER BY Name ASC", Relations[i2]); //--Var
                                    RelRaw = _businesscode.GetDoctors(sortingPar); //--Var
                                    listbox.Items.Add(RelRaw[0].Name);
                                }
                            }
                            listbox.DataBind();
                        }
                    }
                    break;
            }
        }
    }
}