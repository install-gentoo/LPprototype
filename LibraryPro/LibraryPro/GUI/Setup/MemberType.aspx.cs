using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class MemberType : System.Web.UI.Page
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
                    BLibraryPro.MemberType MemTypBLL = new BLibraryPro.MemberType(code);
                    txtTypeName.Text = MemTypBLL.TypeDesc;
                    if (MemTypBLL.ActiveFlag == "I")
                    {
                        ddlStatus.SelectedValue = "I";
                    }
                    txtReason.Text = MemTypBLL.Reason;
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.MemberType MemTypBLL = new BLibraryPro.MemberType(code);
                    MemTypBLL.MemberTypeCode = code;
                    MemTypBLL.DeleteMemberType();
                    Response.Redirect("~/GUI/Setup/MemberType.aspx?act=list&show=1");
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

            BLibraryPro.MemberType BMemberType = new BLibraryPro.MemberType();
            BMemberType.TypeDesc = txtTypeName.Text;
            
            BMemberType.ActiveFlag = ddlStatus.SelectedValue;
            if (ddlStatus.SelectedValue=="I")
            {
                BMemberType.Reason = txtReason.Text;
            }
            else
            {
                BMemberType.Reason = "";
            }

            if (act == "add")
            {
                msgBox.Message = BMemberType.SaveMemberType();
            }
            else if (act == "edit")
            {
                BMemberType.MemberTypeCode = Request.QueryString["code"];
                msgBox.Message = BMemberType.UpdateMemberType();

            }
            else if (act == "del")
            {
                BMemberType.MemberTypeCode = Request.QueryString["code"];
                msgBox.Message = BMemberType.DeleteMemberType();
            }
            Response.Redirect("~/GUI/Setup/MemberType.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.MemberType.GetMemberTypes(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.MemberType.GetMemberTypes(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }
    }
}