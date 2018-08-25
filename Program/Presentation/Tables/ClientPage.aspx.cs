using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation
{
    public partial class ClientPage : System.Web.UI.Page
    {
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = "ORDER BY Name ASC";


        #region Initialise
        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _businesscode.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

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
                Response.Redirect("/index.aspx");
            else
                Load_content();
        }

        protected void Load_content()
        {
            Gridview.DataSource = _businesscode.GetClients(sortingPar);
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
        protected void Sort(object sender, GridViewSortEventArgs e)
        {
            if (e.SortDirection.ToString() == "Ascending")
            {
                string sort = "ORDER BY " + e.SortExpression + " " + GetSortDirection(e.SortExpression);
                sortingPar = sort;

                if (e.SortExpression == "Name")
                {
                    ViewState.Add("Sorting", "Name");
                }
                else if (e.SortExpression == "Adress")
                {
                    ViewState.Add("Sorting", "Adress");
                }
                else if (e.SortExpression == "Postal_Code")
                {
                    ViewState.Add("Sorting", "Postal Code");
                }
                else if (e.SortExpression == "City")
                {
                    ViewState.Add("Sorting", "City");
                }
                else if (e.SortExpression == "Country")
                {
                    ViewState.Add("Sorting", "Country");
                }
                else if (e.SortExpression == "Contact_Person")
                {
                    ViewState.Add("Sorting", "Contact Person");
                }
                else if (e.SortExpression == "Invoice_Info")
                {
                    ViewState.Add("Sorting", "Invoice Info");
                }
                else if (e.SortExpression == "Kind_of_Client")
                {
                    ViewState.Add("Sorting", "Kind of Client");
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
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.ID);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<ClientCode> clients = new List<ClientCode>();
                clients = _businesscode.GetClients("where Client_ID = " + Gridview.DataKeys[e.Row.RowIndex].Value);

                for (int i = 1; i < Gridview.Columns.Count; i++)
                {
                    if (user.Type == "Admin")
                    {
                        UserCode _user = _businesscode.GetUsers($"WHERE User_ID = {clients[0].User_ID};")[0];
                        e.Row.ToolTip = "First added on " + clients[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + clients[0].Date_Last_Edited.ToString("dd-MMM-yyyy") + " by " + _user.Username;
                    }
                    else
                    {
                        e.Row.ToolTip = "First added on " + clients[0].Date_Added.ToString("dd-MMM-yyyy") + ", last edited on " + clients[0].Date_Last_Edited.ToString("dd-MMM-yyyy");
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
        #endregion


        #region Editing
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Gridview.SelectedIndex = -1;

            tbName.Text = string.Empty;
            tbAdress.Text = string.Empty;
            tbPostalCode.Text = string.Empty;
            tbCity.Text = string.Empty;
            tbCountry.Text = string.Empty;
            tbContactPerson.Text = string.Empty;
            tbInvoiceInfo.Text = string.Empty;
            tbKindOfClient.Text = string.Empty;

            modUpdatePanel.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "<script>$('#exampleModal').modal('show');</script>", false);
        }

        protected void Gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int objectID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());
            List<ClientCode> selectedObject = _businesscode.GetClients($"WHERE Client_ID = {objectID}");

            tbName.Text = selectedObject[0].Name;
            tbAdress.Text = selectedObject[0].Adress;
            tbPostalCode.Text = selectedObject[0].Postal_Code;
            tbCity.Text = selectedObject[0].City;
            tbCountry.Text = selectedObject[0].Country;
            tbContactPerson.Text = selectedObject[0].Contact_Person;
            tbInvoiceInfo.Text = selectedObject[0].Invoice_Info;
            tbKindOfClient.Text = selectedObject[0].Kind_of_Client;

            modUpdatePanel.Update();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            modUpdatePanel.Update();

            int objectID = -1;
            if (Gridview.SelectedDataKey != null)
                objectID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());
            List<ClientCode> selectedObject = _businesscode.GetClients($"WHERE Client_ID = {objectID}");

            if (objectID == -1)
            {
                if (tbName.Text != string.Empty)
                {
                    UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                    UserCode user = GetCurrentUser(LoginUser.ID);

                    ClientCode newObject = new ClientCode(0, tbName.Text, tbAdress.Text, tbPostalCode.Text, tbCity.Text, tbCountry.Text, tbContactPerson.Text, tbInvoiceInfo.Text, tbKindOfClient.Text, user.ID, DateTime.Now, DateTime.Now);
                    _businesscode.AddClient(newObject);

                    lbError.Text = "User successfully created";
                    lbError.Visible = true;
                    lbError.ForeColor = System.Drawing.Color.Green;

                    Load_content();
                    gvUpdatePanel.Update();
                }
                else
                {
                    lbError.Text = "Please fill in all required fields";
                    lbError.Visible = true;
                }
            }
            else
            {
                if (tbName.Text != string.Empty)
                {
                    UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                    UserCode user = GetCurrentUser(LoginUser.ID);

                    ClientCode Object = new ClientCode(0, tbName.Text, tbAdress.Text, tbPostalCode.Text, tbCity.Text, tbCountry.Text, tbContactPerson.Text, tbInvoiceInfo.Text, tbKindOfClient.Text, user.ID, DateTime.Now, DateTime.Now);
                    _businesscode.UpdateClient(Object);

                    lbError.Text = "User successfully updated";
                    lbError.Visible = true;
                    lbError.ForeColor = System.Drawing.Color.Green;

                    Load_content();
                    gvUpdatePanel.Update();
                }
                else
                {
                    lbError.Text = "Please fill in all required fields";
                    lbError.Visible = true;
                }
            }
        }

        protected void LnkDelete_Click(object sender, EventArgs e)
        {
            int ObjectID = Convert.ToInt16(Gridview.SelectedDataKey.Value.ToString());
            List<ClientCode> selectedObject = _businesscode.GetClients($"WHERE Client_ID = {ObjectID}");

            _businesscode.DeleteClient(selectedObject[0].ID);

            Load_content();
            gvUpdatePanel.Update();
        }

        protected void Tb_TextChanged(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            tbAdress.Text = string.Empty;
            tbPostalCode.Text = string.Empty;
            tbCity.Text = string.Empty;
            tbCountry.Text = string.Empty;
            tbContactPerson.Text = string.Empty;
            tbInvoiceInfo.Text = string.Empty;
            tbKindOfClient.Text = string.Empty;
        }
        #endregion
    }
}