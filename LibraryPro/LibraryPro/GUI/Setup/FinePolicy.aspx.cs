using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
namespace LibraryPro.GUI.Setup
{
    public partial class FinePolicy : System.Web.UI.Page
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
                    BLibraryPro.FinePolicy FinePolicyBLL = new BLibraryPro.FinePolicy(code);
                    txtTypeName.Text = FinePolicyBLL.FinePolicyDesc;
                    txtFromDays.Text = FinePolicyBLL.FromDays.ToString();
                    txtToDays.Text = FinePolicyBLL.ToDays.ToString();
                    txtFine.Text = FinePolicyBLL.FinePerDay.ToString();
                    if (FinePolicyBLL.ActiveFlag == "I")
                    {
                        ddlStatus.SelectedValue = "I";
                    }
                    txtReason.Text = FinePolicyBLL.Reason;
                }
                else if (act == "del")
                {
                    string code = Request.QueryString["code"];
                    BLibraryPro.FinePolicy FinePolicyBLL = new BLibraryPro.FinePolicy(code);
                    FinePolicyBLL.FinePolicyCode = Convert.ToInt32(code);
                    FinePolicyBLL.DeleteFinePolicy();
                    Response.Redirect("~/GUI/Setup/FinePolicy.aspx?act=list&show=1");
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

            BLibraryPro.FinePolicy BFinePolicy = new BLibraryPro.FinePolicy();
            BFinePolicy.FinePolicyDesc = txtTypeName.Text;
            BFinePolicy.FromDays=Convert.ToInt32(txtFromDays.Text);
            BFinePolicy.ToDays=Convert.ToInt32(txtToDays.Text);
            BFinePolicy.FinePerDay= float.Parse(txtFine.Text);
            
            BFinePolicy.ActiveFlag = ddlStatus.SelectedValue;
            if (ddlStatus.SelectedValue=="I")
            {
                BFinePolicy.Reason = txtReason.Text;
            }
            else
            {
                BFinePolicy.Reason = "";
            }

            if (act == "add")
            {
                msgBox.Message = BFinePolicy.SaveFinePolicy();
            }
            else if (act == "edit")
            {
                BFinePolicy.FinePolicyCode = Convert.ToInt32(Request.QueryString["code"]);
                msgBox.Message = BFinePolicy.UpdateFinePolicy();

            }
            else if (act == "del")
            {
                BFinePolicy.FinePolicyCode = Convert.ToInt32(Request.QueryString["code"]);
                msgBox.Message = BFinePolicy.DeleteFinePolicy();
            }
            Response.Redirect("~/GUI/Setup/FinePolicy.aspx?act=list");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = BLibraryPro.FinePolicy.GetFinePolicies(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

        protected void dgvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSearchResult.PageIndex = e.NewPageIndex;
            DataTable dt = BLibraryPro.FinePolicy.GetFinePolicies(this.txtFilterValue.Text);
            this.lblStatus.Text = "Showing Search Result(s)<br /> " + dt.Rows.Count.ToString() + " record found.";
            dgvSearchResult.DataSource = dt;
            dgvSearchResult.DataBind();
        }

    }
}