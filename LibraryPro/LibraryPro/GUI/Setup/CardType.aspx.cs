using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class CardType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (act == "edit")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.CardType CrdTypBLL = new BLibraryPro.CardType(code);
                    txtTypeName.Text = CrdTypBLL.TypeDesc;
                    txtBookAllowed.Text = CrdTypBLL.BooksAllowed.ToString();
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.CardType CrdTypBLL = new BLibraryPro.CardType(code);
                    CrdTypBLL.CardTypeCode = code;
                    CrdTypBLL.DeleteCardType();
                    Response.Redirect("~/GUI/Setup/CardType.aspx?act=list&show=1");
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

            BLibraryPro.CardType BCardType = new BLibraryPro.CardType();
            BCardType.TypeDesc = txtTypeName.Text;

            BCardType.BooksAllowed = Convert.ToInt32(txtBookAllowed.Text);
            if (act == "add")
            {
                msgBox.Message = BCardType.SaveCardType();
            }
            else if (act == "edit")
            {
                BCardType.CardTypeCode = Request.QueryString["code"];
                msgBox.Message = BCardType.UpdateCardType();

            }
            else if (act == "del")
            {
                BCardType.CardTypeCode = Request.QueryString["code"];
                msgBox.Message = BCardType.DeleteCardType();
            }
            Response.Redirect("~/GUI/Setup/CardType.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.CardType.GetCardTypes(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.CardType.GetCardTypes(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }


    }
}