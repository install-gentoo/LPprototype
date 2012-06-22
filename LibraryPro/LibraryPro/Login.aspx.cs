using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryPro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //place not postback code here.
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLibraryPro.User objBUser = new BLibraryPro.User();
            objBUser.Username = txtUserName.Text;
            objBUser.Password = txtPassword.Text;
            try
            {
                if (objBUser.VerifyUser())
                {
                    Session["login_user"] = objBUser.Username;
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    this.lblStatus.Text = "Username and password provide is invalid";
                    Session["login_user"] = "";
                    //Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception exx)
            {
                Response.Write(exx.Message);
            }
        }

        //protected void btnTest_Click(object sender, EventArgs e)
        //{
        //    BLibraryPro.User _usr = new BLibraryPro.User();
        //    _usr.Username = "ram";
        //    _usr.Password = "ram";
        //    if (_usr.AddUser())
        //    {
        //        Session["message"] = "added";
        //    }
        //    else
        //    {
        //        Session["error"] = "addition error";
        //    }
        //}
    }
}