using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
    public partial class ProfilePage: System.Web.UI.Page
    {
        BusinessCode _business = new BusinessCode();

        protected void Page_Load(object sender,EventArgs e)
        {
            if(!IsPostBack)
            {
                InitPage();
            }
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        private void InitPage()
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            tbUsername.Text = user.Username.ToString();
            tbEmail.Text = user.Email.ToString();

            if (user.Type == "Admin")
            {
                ddType.Items.Add("Account type: " + user.Type.ToString());
                ddType.SelectedIndex = 1;
            }
            else
            {
                ddType.Items.Add("Account type: " + user.Type.ToString());
                ddType.SelectedIndex = 1;
                ddType.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            if(tbPasswordOld.Text == string.Empty)
            {
                try
                {
                    _business.UpdateUser(user.User_ID, tbUsername.Text, tbEmail.Text, user.Password);

                    Session["authenticatedUser"] = GetCurrentUser(LoginUser.User_ID);

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
            }
            else if(tbPasswordOld.Text != string.Empty)
            {
                if (tbPasswordNew1.Text == tbPasswordNew2.Text && tbPasswordNew1.Text != string.Empty)
                {
                    string password = user.Password.ToString();

                    if (HashCode.Verify(tbPasswordOld.Text, password))
                    {
                        _business.UpdateUser(user.User_ID, tbUsername.Text, tbEmail.Text, HashCode.Hash(tbPasswordNew2.Text));

                        Session["authenticatedUser"] = GetCurrentUser(LoginUser.User_ID);

                        lbErrorPassword.Text = "Password successfully updated";
                        lbErrorPassword.ForeColor = System.Drawing.Color.Green;
                        lbErrorPassword.Visible = true;

                        if (LoginUser.Username != tbUsername.Text && LoginUser.Email != tbEmail.Text)
                        {
                            lbErrorUsername.Text = "User successfully updated";
                            lbErrorUsername.Visible = true;
                            lbErrorUsername.ForeColor = System.Drawing.Color.Green;
                        }

                        InitPage();
                    }
                    else
                    {
                        lbErrorPassword.Text = "Old password incorrect";
                        lbErrorPassword.Visible = true;
                    }

                }
                else if (tbPasswordNew1.Text == string.Empty && tbPasswordNew2.Text == string.Empty)
                {
                    _business.UpdateUser(user.User_ID, tbUsername.Text, tbEmail.Text, user.Password);
                    Session["authenticatedUser"] = GetCurrentUser(LoginUser.User_ID);

                    if (LoginUser.Username != tbUsername.Text || LoginUser.Email != tbEmail.Text)
                    {
                        lbErrorUsername.Text = "User successfully updated";
                        lbErrorUsername.Visible = true;
                        lbErrorUsername.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    lbErrorPassword.Text = "Password doesn't match";
                    lbErrorPassword.Visible = true;
                }
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Site/HomePage.aspx");
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            _business.DeleteUser(user.User_ID);

            Response.Redirect("../Index.aspx");
        }
    }
}