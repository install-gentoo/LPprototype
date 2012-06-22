using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlStatus.Items.Insert(0, new ListItem("Active", "A"));
                ddlStatus.Items.Insert(1, new ListItem("InActive", "I"));
                ddlStatus.SelectedValue = "A";

                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Book BookBLL = new BLibraryPro.Book(code);
                    txtBookName.Text = BookBLL.BookDesc.ToString();
                    if (BookBLL.ActiveFlag == "I")
                    {
                        ddlStatus.SelectedValue = "I";
                    }
                    txtReason.Text = BookBLL.ReasonForInactive;

                    DataTable dtcat = BLibraryPro.Category.GetCategories("");
                    ddlCategory.DataSource = dtcat;
                    ddlCategory.DataTextField = "CATEGORY_DESC";
                    ddlCategory.DataValueField = "CATEGORY_CODE";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("Please Select a Category", "0"));
                    ddlCategory.SelectedValue = BookBLL.CategoryCode;

                    DataTable dtpub = BLibraryPro.Publication.GetPublication("");
                    ddlPublication.DataSource = dtpub;
                    ddlPublication.DataTextField = "PUBLICATION_DESC";
                    ddlPublication.DataValueField = "PUBLICATION_CODE";
                    ddlPublication.DataBind();
                    ddlPublication.Items.Insert(0, new ListItem("Please Select a Publication", "0"));
                    ddlPublication.SelectedValue = BookBLL.PublicationCode;
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Book BookBLL = new BLibraryPro.Book(code);
                    BookBLL.BookCode = Convert.ToInt32(code);
                    BookBLL.DeleteBook();
                    Response.Redirect("~/GUI/Setup/Book.aspx?act=list&show=1");
                }
                else if (act == "list")
                {
                    if (Request.QueryString["show"] == "1")
                    {
                        btnFilter_Click(sender, new EventArgs());
                    }
                    btnFilter_Click(sender, new EventArgs());
                }
                else if (act == "add")
                {
                    DataTable dtcat = BLibraryPro.Category.GetCategories("");
                    ddlCategory.DataSource = dtcat;
                    ddlCategory.DataTextField = "CATEGORY_DESC";
                    ddlCategory.DataValueField = "CATEGORY_CODE";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("Please Select a Category", "0"));
                    ddlCategory.SelectedValue = "0";

                    DataTable dtpub = BLibraryPro.Publication.GetPublication("");
                    ddlPublication.DataSource = dtpub;
                    ddlPublication.DataTextField = "PUBLICATION_DESC";
                    ddlPublication.DataValueField = "PUBLICATION_CODE";
                    ddlPublication.DataBind();
                    ddlPublication.Items.Insert(0, new ListItem("Please Select a Publication", "0"));
                    ddlPublication.SelectedValue = "0";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];

            BLibraryPro.Book BBook = new BLibraryPro.Book();
            BBook.BookDesc = txtBookName.Text;
            BBook.PublicationCode = ddlPublication.Text;
            BBook.CategoryCode = ddlCategory.Text;
            BBook.ActiveFlag = ddlStatus.SelectedValue;
            if (ddlStatus.SelectedValue == "I")
            {
                BBook.ReasonForInactive = txtReason.Text;
            }
            else
            {
                BBook.ReasonForInactive = "";
            }

            if (act == "add")
            {
                string bookId = BBook.SaveBook();
                Response.Redirect("~/GUI/Setup/Author.aspx?act=add&bookId=" + bookId);
            }
            else if (act == "edit")
            {
                BBook.BookCode = Convert.ToInt32(Request.QueryString["code"]);
                msgBox.Message = BBook.UpdateBook();

            }
            else if (act == "del")
            {
                BBook.BookCode = Convert.ToInt32(Request.QueryString["code"]);
                msgBox.Message = BBook.DeleteBook();
            }
            Response.Redirect("~/GUI/Setup/Book.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.Book.GetBooks(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.Book.GetBooks(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }
    }
}