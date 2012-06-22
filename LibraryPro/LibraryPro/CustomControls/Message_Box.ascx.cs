using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryPro.CustomControls
{
    public partial class Message_Box : System.Web.UI.UserControl
    {
        public string Message {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}