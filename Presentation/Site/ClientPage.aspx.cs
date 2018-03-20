using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
	public partial class ClientSite: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
		
		protected void Page_Load(object sender,EventArgs e)
		{
			GridView.DataSource = _businesscode.GetClients();
			GridView.DataBind();
		}

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)GridView.DataKeys[e.RowIndex].Value;

            _businesscode.DeleteClient(Convert.ToInt32(id));

            Response.Redirect("../Site/ClientPage.aspx");
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ArrayList CheckBoxArray;
            //if (ViewState["CheckBoxArray"] != null)
            //{
            //    CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            //}
            //else
            //{
            //    CheckBoxArray = new ArrayList();
            //}

            //if (IsPostBack)
            //{
            //    int CheckBoxIndex;
            //    bool CheckAllWasChecked = false;
            //    CheckBox chkAll = (CheckBox)GridView.HeaderRow.Cells[0].FindControl("chkAllSelect");
            //    string checkAllIndex = "chkAllSelect-" + GridView.PageIndex;
            //    if (chkAll.Checked)
            //    {
            //        if (CheckBoxArray.IndexOf(checkAllIndex) == -1)
            //        {
            //            CheckBoxArray.Add(checkAllIndex);
            //        }
            //    }
            //    else
            //    {
            //        if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
            //        {
            //            CheckBoxArray.Remove(checkAllIndex);
            //            CheckAllWasChecked = true;
            //        }
            //    }
            //    for (int i = 0; i < GridView.Rows.Count; i++)
            //    {
            //        if (GridView.Rows[i].RowType == DataControlRowType.DataRow)
            //        {
            //            CheckBox chk = (CheckBox)GridView.Rows[i].Cells[0].FindControl("CheckBox") as CheckBox;
            //            //chk.FindControl("")
            //            CheckBoxIndex = GridView.PageSize * GridView.PageIndex + (i + 1);
            //            if (chk.Checked)
            //            {
            //                if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1 && !CheckAllWasChecked)
            //                {
            //                    CheckBoxArray.Add(CheckBoxIndex);
            //                }
            //            }
            //            else
            //            {
            //                if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1 || CheckAllWasChecked)
            //                {
            //                    CheckBoxArray.Remove(CheckBoxIndex);
            //                }
            //            }
            //        }
            //    }
            //}
            //ViewState["CheckBoxArray"] = CheckBoxArray;
            //GridView.DataSource = dt;
            //GridView.DataBind();

            //string str = string.Empty;
            //string strname = string.Empty;
            //foreach (GridViewRow gvrow in GridView.Rows)
            //{
            //    var container = Master.FindControl("Body");
            //    CheckBox chk = (CheckBox)container.FindControl("chSelect");
            //    if (chk.Checked)
            //    {
            //        int id = 5;
            //str += "<b>EmpId :- </b>" + gvrow.Cells[1].Text + ", ";
            //str += "<b>EmpName :- </b>" + gvrow.Cells[2].Text + ", ";
            //str += "<b>Company :- </b>" + gvrow.Cells[3].Text + ", ";
            //str += "<b>Addess :- </b>" + gvrow.Cells[4].Text;
            //str += "<br />";
            //    }
            //}

            //lblRecord.Text = "<b>Selected EmpDetails: </b>" + str;

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Id");
            //dt.Columns.Add("Name");
            //var container = Master.FindControl("Body");
            //foreach (GridViewRow item in GridView.Rows)
            //{
            //    if ((item.Cells[0].FindControl("cbEdit") as CheckBox).Checked)
            //    {
            //        int id = 0;
            //        DataRow dr = dt.NewRow();
            //        dr["Id"] = item.Cells[1].Text;
            //        dr["Name"] = item.Cells[2].Text;
            //        dt.Rows.Add(dr);
            //    }
            //    else
            //    {
            //        int id = 0;
            //        id = 5;
            //    }
            //}
            //lblMsg.Visible = true;
            //grdData.DataSource = dt;
            //grdData.DataBind();

            //foreach (GridViewRow row in GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        var container = Master.FindControl("Body");
            //        CheckBox chkRow = container.FindControl("cbEdit") as CheckBox;
            //        if (chkRow.Checked == true)
            //        {
            //            Response.Redirect("../index.aspx");
            //            //int id = Convert.ToInt16(row.Cells[1].Text);
            //            //_businesscode.DeleteClient(id);
            //        }
            //    }
            //}

            //foreach (GridViewRow row in GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox CheckRow = (row.Cells[2].FindControl("cbEdit") as CheckBox);
            //        if (CheckRow.Checked)
            //        {

            //        }
            //    }
            //}

            //CheckBox checkBox = (CheckBox)GridView.Rows[my_Data_From_Grid].Cells[2].Controls[0];
            //cbx_Test1_Active.Checked = checkBox.Checked;

            //foreach (GridViewRow rw in GridView.Rows)
            //{
            //    CheckBox chkBx = (CheckBox)rw.FindControl("cbEdit");
            //    if (chkBx != null && chkBx.Checked)
            //    {

            //        //int id = (int)GridView.DataKeys[0].Value;
            //        //id = grid1.Rows[0].Cells[3].Text.ToString();


            //    }
            //}

            //foreach (var gvItem in GridView)
            //{
            //    CheckBox chkItem = (CheckBox)gvItem.FindControl("cbEdit");
            //    if (chkItem.Checked)
            //    {
            //        //Do stuff
            //    }
            //}

            //foreach (GridViewRow row in GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        int id = (int)GridView.DataKeys[0].Value;
            //        CheckBox chkRow = (row.Cells[0].FindControl("cbEdit") as CheckBox);
            //        if (chkRow.Checked)
            //        {
            //            //string id = row.Cells[0].Text;
            //            //int id = (int)GridView.DataKeys[1].Value;
            //        }
            //    }
            //}
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}