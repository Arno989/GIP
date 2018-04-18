using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using CSASPNETMessageBox;

namespace Presentation.Site
{
	public partial class DoctorPage: System.Web.UI.Page
	{
        BusinessCode _businesscode = new BusinessCode();
        string sortingPar = " ORDER BY Name ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = _businesscode.GetDoctors();
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

            Session["DataID"] = DataIDs;
            Session["ListDataSession"] = ListData;
            Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
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
                        List<int> Relations = _businesscode.GetRelationHospitalHasDoctor(Convert.ToInt16(GridView.DataKeys[i].Value));
                        if(_businesscode.GetRelationHospitalHasDoctor(Convert.ToInt16(GridView.DataKeys[i].Value)) != null )
                        {
                            //string title = "Delete warning";
                            //string text = "One or more selected item(s) contain a relation, do you want to delete the relation(s) and the object(s)?";
                            //MessageBox messageBox = new MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.YesOrNo, MessageBox.MessageBoxStyle.StyleA);
                            //messageBox.SuccessEvent.Add("YesModClick");
                            //PopupBox.Text = messageBox.Show(this);
                        }
                        else
                        {
                            int id = (int)GridView.DataKeys[i].Value;
                            _businesscode.DeleteDoctor(Convert.ToInt32(id));
                        }
                    }
                    else
                    {
                    }
                }
            }
            Response.Redirect("../Site/DoctorPage.aspx");
        }

        public static string YesModClick(object sender, EventArgs e)
        {
            string strToRtn = "";
            // The code that you want to execute when the user clicked yes goes here
            return strToRtn;
        }

        protected void Add(object sender, EventArgs e)
        {
            Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
        }
    }
}