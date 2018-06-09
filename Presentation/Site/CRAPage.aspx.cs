using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class CRAPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Name ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetCRAs(sortingPar);
                GridView.DataBind();
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
                Response.Redirect("../SiteEdit/CRAPageEdit.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please select one or more records to edit.')", true);
            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
                    if (chk.Checked)
                    {
                        int RecordID = (int)GridView.DataKeys[i].Value;

                        if (_businesscode.GetRelationCRAHasProjects(Convert.ToInt32(GridView.DataKeys[i].Value)).Count != 0) //--Var
                        {
                            _businesscode.DeleteRelationCRAHasProjects(RecordID); //--Var
                        }
                        _businesscode.DeleteEvaluation(-1, string.Format("OR CRA_ID = {0}", RecordID));
                        _businesscode.DeleteCRA(RecordID);
                    }
                }
            }
            Response.Redirect("../Site/CRAPage.aspx");
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/CRAPageEdit.aspx");
        }
    }
}