using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

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
                GridView.DataSource = _businesscode.GetDoctors(sortingPar);
                GridView.DataBind();
                lbHospitals();
            }
        }

        protected void lbHospitals()
        {
            for (int i = 0; i < GridView.Rows.Count; i++)
            {

                var container = Master.FindControl("Body");
                string lbName = "lbHospitals";
                ListBox listbox = GridView.Rows[i].Cells[11].FindControl(lbName) as ListBox;

                List<int> id = _businesscode.GetRelationHospitalHasDoctor(Convert.ToInt32(GridView.DataKeys[i].Value));
                if (id.Count != 0)
                {
                    string sortingPar = string.Format(" WHERE Hospital_ID = {0}", id[0]);
                    List<HospitalCode> test = new List<HospitalCode>();
                    test = _businesscode.GetHospitals(sortingPar);
                    string test2 = test[0].Name;

                    listbox.Items.Add(test2);
                }
                listbox.DataBind();
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
                        int id = (int)GridView.DataKeys[i].Value;
                        _businesscode.DeleteRelationHospitalHasDoctor(, Convert.ToInt32(id));
                        _businesscode.DeleteDoctor(Convert.ToInt32(id));
                    }
                    else
                    {
                    }
                }
            }
            Response.Redirect("../Site/DoctorPage.aspx");
        }

        protected void Add(object sender, EventArgs e)
        {
            Session["DataID"] = null;
            Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
        }
    }
}