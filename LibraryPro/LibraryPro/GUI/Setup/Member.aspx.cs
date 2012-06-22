using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryPro.GUI.Setup
{
    public partial class Member : System.Web.UI.Page
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
                    BLibraryPro.Member MemberBLL = new BLibraryPro.Member(code);
                    txtFirstName.Text = MemberBLL.FirstName.ToString();
                    txtMiddleName.Text = MemberBLL.MiddleName;
                    txtLastName.Text = MemberBLL.LastName.ToString();
                    txtCityCode.Text = MemberBLL.CityCode.ToString();
                    if (MemberBLL.ActiveFlag == "I")
                    {
                        ddlStatus.SelectedValue = "I";
                    }
                    txtReason.Text = MemberBLL.InactiveReason;

                    DataTable dtmemType = BLibraryPro.MemberType.GetMemberTypes("");
                    ddlMemberType.DataSource = dtmemType;
                    ddlMemberType.DataTextField = "TYPE_DESC";
                    ddlMemberType.DataValueField = "TYPE_CODE";
                    ddlMemberType.DataBind();
                    ddlMemberType.Items.Insert(0, new ListItem("Please Select a Member Type", "0"));
                    ddlMemberType.SelectedValue = MemberBLL.TypeCode.ToString();
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.Member MemberBLL = new BLibraryPro.Member(code);
                    MemberBLL.MemberCode = code;
                    MemberBLL.DeleteMembers();
                    Response.Redirect("~/GUI/Setup/Member.aspx?act=list&show=1");
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
                    DataTable dtmemType = BLibraryPro.MemberType.GetMemberTypes("");
                    ddlMemberType.DataSource = dtmemType;
                    ddlMemberType.DataTextField = "TYPE_DESC";
                    ddlMemberType.DataValueField = "TYPE_CODE";
                    ddlMemberType.DataBind();
                    ddlMemberType.Items.Insert(0, new ListItem("Please Select a Member Type", "0"));
                    ddlMemberType.SelectedValue = "0";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];

            BLibraryPro.Member BMember = new BLibraryPro.Member();
            BMember.TypeCode = ddlMemberType.SelectedValue;
            BMember.FirstName = txtFirstName.Text;
            BMember.MiddleName = txtMiddleName.Text;
            BMember.LastName = txtLastName.Text;
            BMember.CityCode = txtCityCode.Text;
            BMember.ActiveFlag = ddlStatus.SelectedValue;
            if (ddlStatus.SelectedValue == "I")
            {
                BMember.InactiveReason = txtReason.Text;
                BMember.InactivatedBy = Session["login_user"].ToString();
                BMember.InactivedDate = DateTime.Now;
            }
            else
            {
                BMember.InactiveReason = "";
            }

            if (act == "add")
            {
                BMember.RegisteredBy = Session["login_user"].ToString();
                BMember.RegisteredDate = DateTime.Now;
                msgBox.Message = BMember.SaveMember();
            }
            else if (act == "edit")
            {
                BMember.MemberCode = Request.QueryString["code"];
                msgBox.Message = BMember.UpdateMember();

            }
            else if (act == "del")
            {
                BMember.MemberCode = Request.QueryString["code"];
                msgBox.Message = BMember.DeleteMembers();
            }
            Response.Redirect("~/GUI/Setup/Member.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.Member.GetMembers(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.Member.GetMembers(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }
    }
}