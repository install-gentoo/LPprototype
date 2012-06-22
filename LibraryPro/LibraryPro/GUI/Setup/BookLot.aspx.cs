using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class BookLot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.BookLot BookLotBLL = new BLibraryPro.BookLot(code);
                    txtYearOfPublication.Text = BookLotBLL.YearOfPublication.ToString();
                    txtIsbn.Text = BookLotBLL.ISBN;
                    txtPrice.Text = BookLotBLL.Price.ToString();
                    txtPages.Text = BookLotBLL.NoOfPage.ToString();
                    txtNoOfBooks.Text = BookLotBLL.NoOfBooks.ToString();

                    DataTable dtEdition = BLibraryPro.Edition.GetEditions("");
                    ddlEdition.DataSource = dtEdition;
                    ddlEdition.DataTextField = "EDITION_DESC";
                    ddlEdition.DataValueField = "EDITION_CODE";
                    ddlEdition.DataBind();
                    ddlEdition.Items.Insert(0, new ListItem("Please Select Edition", "0"));
                    ddlEdition.SelectedValue = BookLotBLL.EditionCode;

                    DataTable dtBook = BLibraryPro.Book.GetBooks("");
                    ddlBookCode.DataSource = dtBook;
                    ddlBookCode.DataTextField = "BOOK_DESC";
                    ddlBookCode.DataValueField = "BOOK_CODE";
                    ddlBookCode.DataBind();
                    ddlBookCode.Items.Insert(0, new ListItem("Please Select Edition", "0"));
                    ddlBookCode.SelectedValue = BookLotBLL.BookCode.ToString();

                    DataTable dtSource = BLibraryPro.BookSource.GetSources("");
                    ddlSource.DataSource = dtSource;
                    ddlSource.DataTextField = "SOURCE_DESC";
                    ddlSource.DataValueField = "SOURCE_TYPE_CODE";
                    ddlSource.DataBind();
                    ddlSource.Items.Insert(0, new ListItem("Please Select Source", "0"));
                    ddlSource.SelectedValue = BookLotBLL.SourceTypeCode;

                    if (Request.QueryString["view"]=="true")
                    {
                        ddlBookCode.Enabled = false;
                        ddlEdition.Enabled = false;
                        ddlSource.Enabled = false;
                        txtIsbn.ReadOnly = true;
                        txtNoOfBooks.ReadOnly = true;
                        txtPages.ReadOnly = true;
                        txtPrice.ReadOnly = true;
                        txtYearOfPublication.ReadOnly = true;
                    }

                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.BookLot BookLotBLL = new BLibraryPro.BookLot(code);
                    BookLotBLL.BookLotNo = Convert.ToInt32(code);
                    BookLotBLL.DeleteBookLot();
                    Response.Redirect("~/GUI/Setup/BookLot.aspx?act=list&show=1");
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
                    DataTable dtEdition = BLibraryPro.Edition.GetEditions("");
                    ddlEdition.DataSource = dtEdition;
                    ddlEdition.DataTextField = "EDITION_DESC";
                    ddlEdition.DataValueField = "EDITION_CODE";
                    ddlEdition.DataBind();
                    ddlEdition.Items.Insert(0, new ListItem("Please Select Edition", "0"));
                    ddlEdition.SelectedValue ="0";

                    DataTable dtBook = BLibraryPro.Book.GetDDLBooks("");
                    ddlBookCode.DataSource = dtBook;
                    ddlBookCode.DataTextField = "BOOK_DESC";
                    ddlBookCode.DataValueField = "BOOK_CODE";
                    ddlBookCode.DataBind();
                    ddlBookCode.Items.Insert(0, new ListItem("Please Select Book", "0"));
                    ddlBookCode.SelectedValue = Request.QueryString["BookId"];

                    DataTable dtSource = BLibraryPro.BookSource.GetSources("");
                    ddlSource.DataSource = dtSource;
                    ddlSource.DataTextField = "SOURCE_DESC";
                    ddlSource.DataValueField = "SOURCE_TYPE_CODE";
                    ddlSource.DataBind();
                    ddlSource.Items.Insert(0, new ListItem("Please Select Source", "0"));
                    ddlSource.SelectedValue = "0";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];

            BLibraryPro.BookLot BBookLot = new BLibraryPro.BookLot();
            BBookLot.BookCode = Convert.ToInt32(ddlBookCode.SelectedValue);
            BBookLot.EditionCode = ddlEdition.SelectedValue;
            BBookLot.YearOfPublication = Convert.ToInt32(txtYearOfPublication.Text);
            BBookLot.ISBN = txtIsbn.Text;
            BBookLot.Price = float.Parse(txtPrice.Text);
            BBookLot.NoOfPage = Convert.ToInt32(txtPages.Text);
            BBookLot.SourceTypeCode = ddlSource.SelectedValue;

            BBookLot.NoOfBooks = Convert.ToInt32(txtNoOfBooks.Text);

            if (act == "add")
            {
                BBookLot.ReceivedOn = DateTime.Now;
                msgBox.Message = BBookLot.SaveBookLot(Session["login_user"].ToString(), Request.QueryString["AuthorId"]);
            }
            else if (act == "edit")
            {
                BBookLot.BookLotNo = Convert.ToInt32(Request.QueryString["code"]);
                msgBox.Message = BBookLot.UpdateBookLot();

            }
            else if (act == "del")
            {
                BBookLot.BookLotNo = Convert.ToInt32(Request.QueryString["code"]);
                msgBox.Message = BBookLot.DeleteBookLot();
            }
            Response.Redirect("~/GUI/Setup/BookLot.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.BookLot.GetBookLots("");
            //this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.BookLot.GetBookLots("");
            //this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Setup/Book.aspx?act=list");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Setup/BookLot.aspx?act=list");
        }
        
        protected void editBookLot_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Setup/BookLot.aspx?act=edit&code=" + Request.QueryString["code"]);
        }
                        
    }
}