using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using BLibraryPro;

namespace LibraryPro.GUI.Setup
{
    public partial class Issue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                BLibraryPro.Member MLL=new BLibraryPro.Member();
                DataTable dtmcc = BLibraryPro.Member.GetMemberCardCodes("");
                ddlMemberCardCode.DataSource = dtmcc;
                ddlMemberCardCode.DataTextField="MEMBER_CARD_CODE";
                ddlMemberCardCode.DataValueField = "MEMBER_CARD_CODE";
                ddlMemberCardCode.DataBind();
                ddlMemberCardCode.Items.Insert(0, new ListItem("Please select a Member Card Code"));
                ddlMemberCardCode.SelectedValue = "0";

                BLibraryPro.Book BLL = new BLibraryPro.Book();
                DataTable dtbsn = BLibraryPro.Book.GetBookSN("");
                ddlBookSN.DataSource = dtbsn;
                ddlBookSN.DataTextField = "BOOK_SN";
                ddlBookSN.DataValueField = "BOOK_SN";
                ddlBookSN.DataBind();
                ddlBookSN.Items.Insert(0,new ListItem("Please select a Book Serial Number"));
                ddlBookSN.SelectedValue = "0";

                
                
            }
        }

        protected void btnIssueSubmit_Click(object sender, EventArgs e)
        {
            BLibraryPro.Book BLPBook = new BLibraryPro.Book();

            string sql = string.Format(@"INSERT INTO T_ISSUE VALUES ('"+txtIssueCode.Text+@"','"+ddlMemberCardCode.SelectedValue+@"','"+ddlBookSN.SelectedValue+@"','"+txtIB.Text+@"',to_date('"+Convert.ToDateTime(txtDate.Text).ToShortDateString()+@"','MM/dd/yyyy'),to_date('"+Convert.ToDateTime(txtDueDate.Text).ToShortDateString()+@"','MM/dd/yyyy'),'"+ddlReturned.SelectedValue.Substring(0,1)+@"','"+ddlLost.SelectedValue.Substring(0,1)+@"',to_date('"+Convert.ToDateTime(txtReturnedDate.Text).ToShortDateString()+@"','MM/dd/yyyy'),'"+txtReturnedBy.Text+@"',to_number("+txtFineAmount.Text+"))");
            string msg=BLPBook.IssueBook(sql);
            btnIssueSubmit.Text = msg;
            Response.Redirect("~/Default.aspx");

        }
    }
}