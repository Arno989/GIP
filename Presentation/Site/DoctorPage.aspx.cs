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
                ListBoxRel1();
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

                        for (int i2 = 1; i2 < GridView.Columns.Count -1; i2++)
                        {
                            List1.Add(GridView.Rows[i].Cells[i2].Text);
                        }
                        ListData.Add(List1);
                    }
                }
            }

            if(DataIDs.Count != 0)
            {
                Session["DataID"] = DataIDs;
                Session["ListDataSession"] = ListData;
                Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
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
                        List<int> Relations = _businesscode.GetRelationHospitalHasDoctor(Convert.ToInt16(GridView.DataKeys[i].Value));
                        if(_businesscode.GetRelationHospitalHasDoctor(Convert.ToInt16(GridView.DataKeys[i].Value)).Count != 0 )
                        {
                            int DoctorID = (int)GridView.DataKeys[i].Value;
                            List<int> HospitalID = _businesscode.GetRelationHospitalHasDoctor(DoctorID);
                            _businesscode.DeleteRelationHospitalHasDoctor(HospitalID[0], Convert.ToInt32(DoctorID));
                            _businesscode.DeleteDoctor(Convert.ToInt32(DoctorID));
                        }
                        else
                        {
                            int DoctorID = (int)GridView.DataKeys[i].Value;
                            _businesscode.DeleteDoctor(Convert.ToInt32(DoctorID));
                        }
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
        
        protected void ListBoxRel1()//-------------------------------------WIP-------------------------------
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
                    foreach (var item in test)
                    {
                        listbox.Items.Add(test2);
                    }
                }
                listbox.DataBind();
            }
        }
    }
}