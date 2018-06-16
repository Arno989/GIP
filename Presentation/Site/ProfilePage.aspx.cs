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
            UserCode LoginUser = (UserCode) Session["authenticatedUser"];
            UserCode user = GetCurrentUser(LoginUser.User_ID);

            tbUsername.Text = LoginUser.Username;
            tbEmail.Text = LoginUser.Email;
            

        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        protected void BtnSave_Click(object sender,EventArgs e)
        {

        }

        protected void BtnExit_Click(object sender,EventArgs e)
        {

        }

        protected void LnkDelete_Click(object sender,EventArgs e)
        {

        }
    }
}