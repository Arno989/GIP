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


        #region Initialise
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            UserCode user = (UserCode)Session["authenticatedUser"];
            //Check for authenticated user
            if (user != null)
                Load_content();
            else
                Response.Redirect("/index.aspx");
        }

        protected void Load_content()
        {
            Gridview.DataSource = _businesscode.GetCRAs(sortingPar);
            Gridview.DataBind();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in Gridview.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    r.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.Gridview, "Select$" + r.RowIndex, true);
                }
            }
            base.Render(writer);
        }
        #endregion


        #region Sorting
        /*
        protected void Sort(object sender, GridViewSortEventArgs e)
        {
            if (e.SortDirection.ToString() == "Ascending")
            {
                string sort = "ORDER BY " + e.SortExpression + " " + GetSortDirection(e.SortExpression);
                sortingPar = sort;

                if (e.SortExpression == "Username")
                {
                    ViewState.Add("Sorting", "Username");
                }
                else if (e.SortExpression == "Email")
                {
                    ViewState.Add("Sorting", "E-mail");
                }
                else if (e.SortExpression == "Type")
                {
                    ViewState.Add("Sorting", "Account type");
                }

                Load_content();
            }
        }

        protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                string imgAsc = @" <img src='\Images\round_arrow_drop_up_black_18dp.png' title='Ascending' />";
                string imgDes = @" <img src='\Images\round_arrow_drop_down_black_18dp.png' title='Descendng' />";

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        LinkButton lnkbtn = (LinkButton)e.Row.Cells[1].Controls[0];
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
                                lnkbtn.Text += imgAsc;
                            else
                                lnkbtn.Text += imgDes;
                        }
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
                        sortDirection = "DESC";
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
        */
        #endregion


        #region Editing
        protected void Gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //take id of selected object and load data in modal
            int objectID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());
            List<CRACode> selectedObject = _businesscode.GetCRAs($"WHERE CRA_ID = {objectID}");

            tbName.Text = selectedObject[0].Name;
            tbCV.Text = selectedObject[0].CV;
            tbEmail.Text = selectedObject[0].Email;
            tbPhone1.Text = selectedObject[0].Phone1;
            tbPhone2.Text = selectedObject[0].Phone2;

            modUpdatePanel.Update();
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "<script>$('#exampleModal').modal('show');</script>", false);
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Gridview.SelectedIndex = -1;

            tbName.Text = string.Empty;
            tbCV.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPhone1.Text = string.Empty;
            tbPhone2.Text = string.Empty;

            modUpdatePanel.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "<script>$('#exampleModal').modal('show');</script>", false);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            modUpdatePanel.Update();

            UserCode user = (UserCode)Session["authenticatedUser"];
            int objectID = -1;

            if (Gridview.SelectedIndex != -1)
                objectID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());

            List<CRACode> selectedObject = _businesscode.GetCRAs($"WHERE CRA_ID = {objectID}");
            
            if (tbName.Text != string.Empty && tbEmail.Text != string.Empty)
            {
                if (_businesscode.IsValidEmail(tbEmail.Text))
                {
                    CRACode subject = new CRACode(objectID, tbName.Text, tbCV.Text, tbEmail.Text, tbPhone1.Text, tbPhone2.Text, user.ID, DateTime.Now, DateTime.Now );

                    if (Gridview.SelectedIndex != -1)
                    {
                        _businesscode.UpdateCRA(subject);
                    }
                    else
                    {
                        _businesscode.AddCRA(subject);
                    }
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "<script>$('#exampleModal').modal('hide');</script>", false);

                    lbNotification.Visible = false;
                    Load_content();
                    gvUpdatePanel.Update();
                }
                else
                {
                    lbNotification.Text = "Please fill in a valid email adress";
                    lbNotification.Visible = true;
                }
            }
            else
            {
                lbNotification.Text = "Please fill in the required fields";
                lbNotification.Visible = true;
            }
        }

        protected void LnkDelete_Click(object sender, EventArgs e)
        {
            int ObjectID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());
            List<CRACode> selectedObject = _businesscode.GetCRAs($"WHERE CRA_ID = {ObjectID}");

            _businesscode.DeleteCRA(selectedObject[0].ID);

            Gridview.SelectedIndex = -1;
            lbNotification.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "<script>$('#exampleModal').modal('hide');</script>", false);
            Load_content();
            gvUpdatePanel.Update();
        }

        protected void Tb_TextChanged(object sender, EventArgs e)
        {
            lbNotification.Visible = false;
            modUpdatePanel.Update();
        }
        #endregion
        
    }
}