using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLibraryPro;

namespace LibraryPro.GUI.Setup
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Category CatBLL = new BLibraryPro.Category(code);
                    txtCategoryName.Text = CatBLL.CategoryDesc;
                    txtRemarks.Text = CatBLL.remarks;                    
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Category CatBLL = new BLibraryPro.Category(code);
                    CatBLL.CategoryCode = code;
                    CatBLL.DeleteCatagory();
                    Response.Redirect("~/GUI/Setup/Category.aspx?act=list&show=1");
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
            
            BLibraryPro.Category BCatagory = new BLibraryPro.Category();
            BCatagory.CategoryDesc = txtCategoryName.Text;
           
            BCatagory.remarks = txtRemarks.Text;
            if (act == "add")
            {
                msgBox.Message = BCatagory.SaveCategory();
            }
            else if (act == "edit")
            {
                BCatagory.CategoryCode = Request.QueryString["code"];
                msgBox.Message = BCatagory.UpdateCategory();
                
            }
            else if (act == "del")
            {
                BCatagory.CategoryCode = Request.QueryString["code"];
                msgBox.Message = BCatagory.DeleteCatagory();
            }
            Response.Redirect("~/GUI/Setup/Category.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //
            
            //
            DataTable dt = BLibraryPro.Category.GetCategories(this.txtFilterValue.Text);
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
            DataTable dt = BLibraryPro.Category.GetCategories(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        //protected void dgvSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.ToString() == "select")
        //    {

        //        int index = Convert.ToInt32(e.CommandArgument);

        //        // Retrieve the row that contains the button clicked 
        //        // by the user from the Rows collection.
        //        GridViewRow row = dgvSearchResult.Rows[index];

        //        // Create a new ListItem object for the contact in the row.    

        //        string a = row.Cells[0].Text;
        //        string Aa = row.Cells[1].Text;
        //        string aAA = row.Cells[2].Text;

        //        //ListItem item = new ListItem();
        //        //item.Text = Server.HtmlDecode(row.Cells[2].Text) + " " +
        //        //  Server.HtmlDecode(row.Cells[3].Text);
        //    }

        //}

        
    }
}