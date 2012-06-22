using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLibraryPro;
using System.Data;
namespace LibraryPro.GUI.Setup
{
    public partial class BookEdition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Edition EdiBLL = new BLibraryPro.Edition(code);
                    txtEditionName.Text = EdiBLL.EditionDesc;
                    txtRemarks.Text = EdiBLL.Remarks;
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Edition EdiBLL = new BLibraryPro.Edition(code);
                    EdiBLL.EditionCode = code;
                    EdiBLL.DeleteEdition();
                    Response.Redirect("~/GUI/Setup/BookEdition.aspx?act=list&show=1");
                }
                else if (act == "list")
                {
                    if (Request.QueryString["show"] == "1")
                    {
                        btnFilter_Click(sender, new EventArgs());
                    }
                    btnFilter_Click(sender, new EventArgs());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];

            BLibraryPro.Edition BEdition = new Edition();
            BEdition.EditionDesc = txtEditionName.Text;
            BEdition.Remarks = txtRemarks.Text;
            //BLibraryPro.Publication BPublication = new BLibraryPro.Publication();
            //BPublication.PublicationDesc = txtPublicationName.Text;
            //BPublication.CountryCode = txtCountryCode.Text;
            //BPublication.EstDate = Convert.ToDateTime(txtEstDate.Text);


            if (act == "add")
            {
                msgBox.Message = BEdition.SaveEdition();
            }
            else if (act == "edit")
            {
                BEdition.EditionCode = Request.QueryString["code"];
                msgBox.Message = BEdition.UpdateEditon();
            }
            else if (act == "del")
            {
                BEdition.EditionCode = Request.QueryString["code"];
                msgBox.Message = BEdition.DeleteEdition();
            }
            Response.Redirect("~/GUI/Setup/BookEdition.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.Edition.GetEditions(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.Edition.GetEditions(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

    }
}