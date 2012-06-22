using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class BookSource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.BookSource SrcBLL = new BLibraryPro.BookSource(code);
                    txtSourceName.Text = SrcBLL.SourceDesc;
                    txtRemarks.Text = SrcBLL.remarks;                    
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.BookSource SrcBLL = new BLibraryPro.BookSource(code);
                    SrcBLL.SourceTypeCode = code;
                    SrcBLL.DeleteSource();
                    Response.Redirect("~/GUI/Setup/BookSource.aspx?act=list&show=1");
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

            BLibraryPro.BookSource BSource = new BLibraryPro.BookSource();
            BSource.SourceDesc = txtSourceName.Text;
           
            BSource.remarks = txtRemarks.Text;
            if (act == "add")
            {
                msgBox.Message = BSource.SaveSource();
            }
            else if (act == "edit")
            {
                BSource.SourceTypeCode = Request.QueryString["code"];
                msgBox.Message = BSource.UpdateSource();
                
            }
            else if (act == "del")
            {
                BSource.SourceTypeCode = Request.QueryString["code"];
                msgBox.Message = BSource.DeleteSource();
            }
            Response.Redirect("~/GUI/Setup/BookSource.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //
            
            //
            DataTable dt = BLibraryPro.BookSource.GetSources(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> "+dt.Rows.Count.ToString()+" record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
          //dgvSearchResult.SelectedRow
        }

        protected void dgvSearchResult_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.BookSource.GetSources(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.BookSource.GetSources(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }
    }
}