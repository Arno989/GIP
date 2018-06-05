using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class ContractPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Legal_country ASC";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetContracts(sortingPar);
                GridView.DataBind();
                FillProject();
                FillClient();
            }
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
                Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
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
                        _businesscode.DeleteContract(Convert.ToInt32(id), "");
                        CheckedOrNot = true;
                    }
                }
            }
            if(CheckedOrNot == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to delete.')", true);
            }
            else
            {
                Response.Redirect("../Site/ContractPage.aspx");
            }
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/ContractPageEdit.aspx");
        }

        public void FillProject()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //projectID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", GridView.DataKeys[i].Value);
                List<ContractCode> CurrentContract = new List<ContractCode>();
                CurrentContract = _businesscode.GetContracts(sortingPar1);
                int projectID = CurrentContract[0].ProjectID;

                //projectID omzetten naar project title
                string sortingPar2 = string.Format(" WHERE Project_ID = {0}", projectID);
                List<ProjectCode> ProjectRelation = new List<ProjectCode>();
                ProjectRelation = _businesscode.GetProjects(sortingPar2);
                string ProjectTitle = ProjectRelation[0].Title;

                GridView.Rows[i].Cells[5].Text = ProjectTitle;
            }
        }

        public void FillClient()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                //projectID krijgen van de current row in de gridvieuw
                string sortingPar1 = string.Format(" WHERE Contract_ID = {0}", GridView.DataKeys[i].Value);
                List<ContractCode> CurrentContract = new List<ContractCode>();
                CurrentContract = _businesscode.GetContracts(sortingPar1);
                int clientID = CurrentContract[0].ClientID;

                //projectID omzetten naar project title
                string sortingPar2 = string.Format(" WHERE Client_ID = {0}", clientID);
                List<ClientCode> ClientRelation = new List<ClientCode>();
                ClientRelation = _businesscode.GetClients(sortingPar2);
                string ClientName = ClientRelation[0].Name;

                GridView.Rows[i].Cells[6].Text = ClientName;
            }
        }
    }
}