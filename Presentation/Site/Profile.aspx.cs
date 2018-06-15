using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.Site
{
    public partial class Profile : System.Web.UI.Page
    {
        BusinessCode _business = new BusinessCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        protected void InitPage()
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            lblUserText.Text = user.Username;
            lblEmailText.Text = user.Email;
            lbltypeText.Text = user.Type;
            lblPasswordText.Text = user.Password;

            lblUserText.Visible = true;
            lblEmailText.Visible = true;
            lblPasswordText.Visible = true;

            tbUserChange.Visible = false;
            tbEmailChange.Visible = false;

            btnChange.Visible = true;
            btnChangePassword.Visible = true;
            btnDelete.Visible = true;

            btnChangeSave.Visible = false;

            lblPasswordText.Visible = true;

            tbPasswordChangeOld.Visible = false;
            tbPasswordChange1.Visible = false;
            tbPasswordChange2.Visible = false;

            btnChangePasswordSave.Visible = false;
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            _business.DeleteUser(user.User_ID);
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            lblUserText.Visible = false;
            lblEmailText.Visible = false;
            lblPasswordText.Visible = false;

            tbUserChange.Visible = true;
            tbUserChange.Text = user.Username;
            tbEmailChange.Visible = true;
            tbEmailChange.Text = user.Email;

            btnChange.Visible = false;
            btnChangePassword.Visible = false;
            btnDelete.Visible = false;

            btnChangeSave.Visible = true;
        }

        protected void btnChangeSave_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            try
            {
                _business.UpdateUser(user.User_ID, tbUserChange.Text, tbEmailChange.Text, user.Password);
                InitPage();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Username already exists. Please choose another username.')", true);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            lblPasswordText.Visible = false;

            tbPasswordChangeOld.Visible = true;
            tbPasswordChange1.Visible = true;
            tbPasswordChange2.Visible = true;

            btnChange.Visible = false;
            btnChangePassword.Visible = false;
            btnDelete.Visible = false;

            btnChangePasswordSave.Visible = true;
            
        }

        protected void btnChangePasswordSave_Click(object sender, EventArgs e)
        {
            UserCode LoginUser = (UserCode)Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            if (tbPasswordChange1.Text == tbPasswordChange2.Text)
            {
                string username = user.Username;

                List<UserCode> userList = _business.GetUsers(string.Format("WHERE Username = '{0}'", username));
                string password = userList[0].Password.ToString();

                if (HashCode.Verify(tbPasswordChangeOld.Text, password))
                {
                    _business.UpdateUser(user.User_ID, user.Username, user.Email, HashCode.Hash(tbPasswordChange2.Text));
                    InitPage();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Old password is incorrect.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('You typed in two different new passwords. Please make sure you type in the richt password!')", true);
            }
        }

    }
}