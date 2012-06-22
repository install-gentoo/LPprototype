using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLibraryPro;
using System.Data;
using System.Globalization;
namespace LibraryPro.GUI.Setup
{
    public partial class Publication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Publication PubBLL = new BLibraryPro.Publication(code);
                    txtPublicationName.Text = PubBLL.PublicationDesc;
                    txtCountryCode.Text = PubBLL.CountryCode;
                    txtEstDate.Text = Convert.ToDateTime(PubBLL.EstDate).ToShortDateString();

                    PubBLL.UpdatePublication();
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Publication PubBLL = new BLibraryPro.Publication(code);

                    PubBLL.PublicationCode = code;
                    PubBLL.DeletePublication();
                    Response.Redirect("~/GUI/Setup/Publication.aspx?act=list&show=1");

                    
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
            BLibraryPro.Publication BPublication = new BLibraryPro.Publication();
            BPublication.PublicationDesc =txtPublicationName.Text;
            BPublication.CountryCode=txtCountryCode.Text;
            BPublication.EstDate = Convert.ToDateTime(txtEstDate.Text);
            
            
            if (act == "add")
            {
                msgBox.Message = BPublication.SavePublication();
            }
            else if (act == "edit")
            {
                BPublication.PublicationCode=Request.QueryString["code"];
               
                msgBox.Message = BPublication.UpdatePublication();

            }
            else if (act == "del")
            {
                BPublication.PublicationCode = Request.QueryString["code"];

                msgBox.Message = BPublication.DeletePublication();
            }
            Response.Redirect("~/GUI/Setup/Publication.aspx?act=list");
        }

        protected void dgvPublicationResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.Publication.GetPublication(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> "+dt.Rows.Count.ToString()+" record found.";
            dgvPublicationResult.DataSource = dt;
            dgvPublicationResult.DataBind();
        }

        protected void dgvPublicationResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPublicationResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.Publication.GetPublication(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvPublicationResult.DataSource = dt;
            dgvPublicationResult.DataBind();
        }
    }
}