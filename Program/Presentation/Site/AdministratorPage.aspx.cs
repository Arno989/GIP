using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation
{
    public partial class Testpage : System.Web.UI.Page
    {
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Username ASC";


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
            if (user == null)
                Response.Redirect("/Site/index.aspx");
            if (user.Type == "Admin")
                Load_content();
            else
                Response.Redirect("/Site/index.aspx");
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _businesscode.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        protected void Load_content()
        {
            Gridview.DataSource = _businesscode.GetUsers(sortingPar);
            Gridview.DataBind();
        }

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
                            {
                                lnkbtn.Text += imgAsc;
                            }
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
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void Gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());
            
            List<UserCode> selectedUser = _businesscode.GetUsers($"WHERE User_ID = {userID}");

            tbUsername.Text = selectedUser[0].Username.ToString();
            tbEmail.Text = selectedUser[0].Email.ToString();

            ddAccountType.SelectedValue = selectedUser[0].Type;
        }


        protected void tb_TextChanged(object sender, EventArgs e)
        {
            lbErrorUsername.Text = string.Empty;
            lbErrorPassword.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());

            List<UserCode> selectedUser = _businesscode.GetUsers($"WHERE User_ID = {userID}");
            
            if (tbPasswordNew.Text == string.Empty)
            {
                try
                {
                    _businesscode.UpdateUser(selectedUser[0].User_ID, tbUsername.Text, tbEmail.Text, selectedUser[0].Password);
                    
                    lbErrorUsername.Text = "User successfully updated";
                    lbErrorUsername.Visible = true;
                    lbErrorUsername.ForeColor = System.Drawing.Color.Green;

                    InitPage();

                }
                catch
                {
                    lbErrorUsername.Text = "Username already exists, choose another name";
                    lbErrorUsername.Visible = true;
                }

                Session["authenticatedUser"] = GetCurrentUser(selectedUser[0].User_ID);

                InitPage();
            }
            else
            {
                try
                {
                    _businesscode.UpdateUser(selectedUser[0].User_ID, tbUsername.Text, tbEmail.Text, HashCode.Hash(tbPasswordNew.Text));

                    lbErrorPassword.Text = "Password successfully updated";
                    lbErrorPassword.ForeColor = System.Drawing.Color.Green;
                    lbErrorPassword.Visible = true;

                    if (selectedUser[0].Username != tbUsername.Text || selectedUser[0].Email != tbEmail.Text)
                    {
                        lbErrorUsername.Text = "User successfully updated";
                        lbErrorUsername.Visible = true;
                        lbErrorUsername.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch
                {
                    lbErrorUsername.Text = "Username already exists, choose another name";
                    lbErrorUsername.Visible = true;
                }

                Session["authenticatedUser"] = GetCurrentUser(selectedUser[0].User_ID);
                
                InitPage();
            }

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/AdministratorPage.aspx");
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());

            List<UserCode> selectedUser = _businesscode.GetUsers($"WHERE User_ID = {userID}");

            _businesscode.DeleteUser(selectedUser[0].User_ID);
        }
        
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in Gridview.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    r.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    r.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    r.ToolTip = "Click to select row";
                    r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.Gridview, "Select$" + r.RowIndex, true);

                }
            }
            base.Render(writer);
        }
    }
}