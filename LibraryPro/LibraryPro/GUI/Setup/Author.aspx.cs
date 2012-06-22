using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class Author : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Author AuthorBLL = new BLibraryPro.Author(code);
                    txtFirstName.Text = AuthorBLL.FirstName.ToString();
                    txtMiddleName.Text = AuthorBLL.MiddleName;
                    txtLastName.Text = AuthorBLL.LastName.ToString();
                    txtCountryCode.Text = AuthorBLL.CountryCode.ToString();

                    if (Request.QueryString["view"] == "true")
                    {
                        txtFirstName.ReadOnly = true;
                        txtMiddleName.ReadOnly = true;
                        txtLastName.ReadOnly = true;
                        txtCountryCode.ReadOnly = true;
                    }
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Author AuthorBLL = new BLibraryPro.Author(code);
                    AuthorBLL.AuthorCode = code;
                    AuthorBLL.DeleteAuthor();
                    Response.Redirect("~/GUI/Setup/Author.aspx?act=list&show=1");
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
                    DataTable dtAuthor = BLibraryPro.Author.GetAuthors(this.txtFilterValue.Text);
                    ddlAuthor.DataSource = dtAuthor;
                    ddlAuthor.DataTextField = "NAME";
                    ddlAuthor.DataValueField = "AUTHOR_CODE";
                    ddlAuthor.DataBind();

                    hdnBookId.Value = Request.QueryString["bookId"];
                    ddlAuthor.Items.Insert(0, new ListItem("Please Select Author", "0"));
                    ddlAuthor.SelectedValue = "0";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];

            BLibraryPro.Author BAuthor = new BLibraryPro.Author();
            BAuthor.FirstName = txtFirstName.Text;
            BAuthor.MiddleName = txtMiddleName.Text;
            BAuthor.LastName = txtLastName.Text;
            BAuthor.CountryCode = txtCountryCode.Text;
            

            if (act == "add")
            {
                string authorId = "";
                if (UseExistingAuthor.Checked)
                {
                    authorId = ddlAuthor.SelectedValue.ToString();
                    Response.Redirect("~/GUI/Setup/BookLot.aspx?act=add&BookId=" + hdnBookId.Value.ToString() + "&AuthorId=" + authorId);
                }
                else
                {
                    authorId = BAuthor.SaveAuthor();
                    Response.Redirect("~/GUI/Setup/BookLot.aspx?act=add&BookId=" + hdnBookId.Value.ToString() + "&AuthorId=" + authorId);
                }
                
            }
            else if (act == "edit")
            {
                BAuthor.AuthorCode = Request.QueryString["code"];
                msgBox.Message = BAuthor.UpdateAuthor();

            }
            else if (act == "del")
            {
                BAuthor.AuthorCode = Request.QueryString["code"];
                msgBox.Message = BAuthor.DeleteAuthor();
            }
            Response.Redirect("~/GUI/Setup/Author.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.Author.GetAuthors(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.Author.GetAuthors(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void UseExistingAuthor_CheckedChanged(object sender, EventArgs e)
        {
            if (UseExistingAuthor.Checked)
            {
                divExistingAuthor.Style["display"] = "block";
                divNewAuthor.Style["display"] = "none";

                rfvAuthor.Enabled = true;
                rfvFirstName.Enabled = false;
                rfvLastName.Enabled = false;
                rfvCountryCode.Enabled = false;
            }
            else
            {
                divExistingAuthor.Style["display"] = "none";
                divNewAuthor.Style["display"] = "block";

                rfvAuthor.Enabled = false;
                rfvFirstName.Enabled = true;
                rfvLastName.Enabled = true;
                rfvCountryCode.Enabled = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Setup/Author.aspx?act=list");
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Setup/Book.aspx?act=list");
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Setup/Author.aspx?act=edit&code="+Request.QueryString["code"]);
        }
        
    }
}